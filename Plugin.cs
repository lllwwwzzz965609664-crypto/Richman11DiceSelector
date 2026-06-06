using System;
using System.Collections.Generic;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace Richman11DiceSelector
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    public sealed class Plugin : BaseUnityPlugin
    {
        public const string PluginGuid = "local.richman11.diceselector";
        public const string PluginName = "Richman11DiceSelector";
        public const string PluginVersion = "1.0.0";

        private static ManualLogSource LogRef;
        private static Harmony harmony;
        private static int pendingPoint;
        private static float pendingUntil;
        private static bool pluginEnabled = true;
        private static Rect windowRect = new Rect(20f, 80f, 320f, 110f);

        private static Type battleMgrType;
        private static FieldInfo instanceField;
        private static PropertyInfo instanceProperty;
        private static FieldInfo tmpDiceField;
        private static FieldInfo uiStaffField;
        private static MethodInfo isNetMethod;

        private void Awake()
        {
            LogRef = Logger;
            LogRef.LogInfo("Richman11DiceSelector loaded successfully.");

            harmony = new Harmony(PluginGuid);
            if (!TryInstallPatch())
            {
                LogDiceCandidates();
            }
        }

        private void OnDestroy()
        {
            if (harmony != null)
            {
                harmony.UnpatchSelf();
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0))
            {
                ClearPending("user cleared selection");
                return;
            }

            for (int i = 1; i <= 6; i++)
            {
                KeyCode top = (KeyCode)((int)KeyCode.Alpha0 + i);
                KeyCode pad = (KeyCode)((int)KeyCode.Keypad0 + i);
                if (Input.GetKeyDown(top) || Input.GetKeyDown(pad))
                {
                    pendingPoint = i;
                    pendingUntil = Time.realtimeSinceStartup + 10f;
                    LogRef.LogInfo("User selected next dice point: " + i + " (valid for 10 seconds).");
                    return;
                }
            }

            if (pendingPoint != 0 && Time.realtimeSinceStartup > pendingUntil)
            {
                ClearPending("selection expired");
            }
        }

        private void OnGUI()
        {
            windowRect = GUI.Window(912611, windowRect, DrawWindow, "Richman11 Dice Selector");
        }

        private static void DrawWindow(int id)
        {
            GUILayout.Label("Enabled: " + (pluginEnabled ? "Yes" : "No"));
            GUILayout.Label("Next dice point: " + (pendingPoint == 0 ? "None" : pendingPoint.ToString()));
            GUILayout.Label("Press 1-6 to set next point, 0 to clear.");
            GUI.DragWindow();
        }

        private static bool TryInstallPatch()
        {
            Type battleBaseType = AccessTools.TypeByName("BattleBase");
            battleMgrType = AccessTools.TypeByName("BattleMgr");
            if (battleBaseType == null || battleMgrType == null)
            {
                LogRef.LogWarning("Could not find BattleBase or BattleMgr.");
                return false;
            }

            MethodInfo getDice = AccessTools.Method(battleBaseType, "GetDice", new[] { typeof(int), typeof(List<int>).MakeByRefType() });
            if (getDice == null)
            {
                LogRef.LogWarning("Could not find BattleBase.GetDice(int, ref List<int>).");
                return false;
            }

            instanceField = AccessTools.Field(battleMgrType, "<Instance>k__BackingField");
            instanceProperty = AccessTools.Property(battleMgrType, "Instance");
            tmpDiceField = AccessTools.Field(battleMgrType, "tmpDice");
            uiStaffField = AccessTools.Field(battleMgrType, "iUIStaff");
            isNetMethod = AccessTools.Method(battleMgrType, "IsNet");

            if (tmpDiceField == null || uiStaffField == null)
            {
                LogRef.LogWarning("BattleMgr.tmpDice or BattleMgr.iUIStaff was not found.");
                return false;
            }

            MethodInfo prefix = AccessTools.Method(typeof(Plugin), "GetDicePrefix");
            MethodInfo postfix = AccessTools.Method(typeof(Plugin), "GetDicePostfix");
            harmony.Patch(getDice, new HarmonyMethod(prefix), new HarmonyMethod(postfix));
            LogRef.LogInfo("Hooked dice method: BattleBase.GetDice(int staff, ref List<int> ortList).");
            return true;
        }

        private static void GetDicePrefix(int staff, ref PatchState __state)
        {
            __state = new PatchState();
            if (!pluginEnabled || pendingPoint < 1 || pendingPoint > 6 || Time.realtimeSinceStartup > pendingUntil)
            {
                return;
            }

            object mgr = GetBattleMgr();
            if (mgr == null)
            {
                return;
            }

            if (IsNetworkGame(mgr))
            {
                return;
            }

            int uiStaff = Convert.ToInt32(uiStaffField.GetValue(mgr));
            if (staff != uiStaff)
            {
                LogRef.LogInfo("Pending dice point ignored for non-player staff " + staff + "; UI staff is " + uiStaff + ".");
                return;
            }

            int[] tmpDice = tmpDiceField.GetValue(mgr) as int[];
            if (tmpDice == null || tmpDice.Length == 0)
            {
                LogRef.LogWarning("BattleMgr.tmpDice is unavailable; cannot override dice safely.");
                return;
            }

            __state.Applied = true;
            __state.Manager = mgr;
            __state.TempDice = tmpDice;
            __state.OldValues = (int[])tmpDice.Clone();
            __state.Point = ClampPoint(pendingPoint);
            tmpDice[0] = __state.Point;
        }

        private static void GetDicePostfix(PatchState __state)
        {
            if (__state == null || !__state.Applied)
            {
                return;
            }

            try
            {
                if (__state.TempDice != null && __state.OldValues != null)
                {
                    int len = Math.Min(__state.TempDice.Length, __state.OldValues.Length);
                    for (int i = 0; i < len; i++)
                    {
                        __state.TempDice[i] = __state.OldValues[i];
                    }
                }
            }
            finally
            {
                LogRef.LogInfo("Actually overrode next normal dice result with: " + __state.Point + ".");
                ClearPending("dice override consumed");
            }
        }

        private static object GetBattleMgr()
        {
            if (instanceProperty != null)
            {
                object value = instanceProperty.GetValue(null, null);
                if (value != null)
                {
                    return value;
                }
            }

            return instanceField == null ? null : instanceField.GetValue(null);
        }

        private static bool IsNetworkGame(object mgr)
        {
            if (isNetMethod == null)
            {
                return false;
            }

            try
            {
                return Convert.ToBoolean(isNetMethod.Invoke(mgr, null));
            }
            catch (Exception ex)
            {
                LogRef.LogWarning("Could not query BattleMgr.IsNet(): " + ex.Message);
                return true;
            }
        }

        private static int ClampPoint(int value)
        {
            if (value < 1) return 1;
            if (value > 6) return 6;
            return value;
        }

        private static void ClearPending(string reason)
        {
            if (pendingPoint != 0)
            {
                LogRef.LogInfo("Cleared pending dice point: " + reason + ".");
            }

            pendingPoint = 0;
            pendingUntil = 0f;
        }

        private static void LogDiceCandidates()
        {
            LogRef.LogWarning("No safe dice result method was hooked. Candidate methods found in Assembly-CSharp:");
            LogRef.LogWarning("BattleMgr.DiceBegin(int staffpos)");
            LogRef.LogWarning("BattleMgr.DiceUpdate()");
            LogRef.LogWarning("BattleMgr.DiceOver(int staffpos)");
            LogRef.LogWarning("BattleMgr.ThrowDice(int staff, int endpos)");
            LogRef.LogWarning("BattleBase.GetDice(int staff, ref List<int> ortList)");
            LogRef.LogWarning("BattleBase.GetDiceMoveList(int endpos, int order, ref List<int> ortList, ref int ort, bool, int)");
            LogRef.LogWarning("Please send BepInEx\\LogOutput.log for further analysis.");
        }

        private sealed class PatchState
        {
            public bool Applied;
            public object Manager;
            public int[] TempDice;
            public int[] OldValues;
            public int Point;
        }
    }
}
