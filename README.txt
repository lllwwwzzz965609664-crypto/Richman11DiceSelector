Richman11DiceSelector
=====================

Local BepInEx 5 + Harmony plugin for Steam single-player Richman11 testing.
Do not use it in online mode.

Install:
Put Richman11DiceSelector.dll here:
D:\Steam\steamapps\common\Richman11\BepInEx\plugins

Dice keys:
F1 = next normal dice roll 1
F2 = next normal dice roll 2
F3 = next normal dice roll 3
F4 = next normal dice roll 4
F5 = next normal dice roll 5
F6 = next normal dice roll 6
BackQuote (`~ key) = clear current selection

Speed keys:
F7 = decrease speed by 0.25, minimum x1.0
F8 = increase speed by 0.25, maximum x3.0
F9 = toggle speed boost

Speed boost is enabled by default at x1.8.
The status window is hidden by default.
The plugin uses Unity Time.timeScale and adjusts Time.fixedDeltaTime.
When destroyed, it restores Time.timeScale = 1f and the original fixedDeltaTime.

Window key:
F10 = show/hide the plugin status window

Technical notes:
The dice hook remains BattleBase.GetDice(int staff, ref List<int> ortList).
The plugin does not hook DelCard, card deletion, per-step movement, remaining-step decrement, or event settlement.

If it does not work, send:
D:\Steam\steamapps\common\Richman11\BepInEx\LogOutput.log
