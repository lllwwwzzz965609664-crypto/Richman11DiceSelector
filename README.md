# Richman11DiceSelector

Local BepInEx 5 + Harmony plugin for Steam single-player Richman11 testing.

Do not use it in online mode. It does not bypass Steam and does not modify account, network, or anti-cheat behavior.

## Install

Put `Richman11DiceSelector.dll` here:

`D:\Steam\steamapps\common\Richman11\BepInEx\plugins`

## Dice Keys

| Key | Action |
| --- | --- |
| F1 | Set next normal dice roll to 1 |
| F2 | Set next normal dice roll to 2 |
| F3 | Set next normal dice roll to 3 |
| F4 | Set next normal dice roll to 4 |
| F5 | Set next normal dice roll to 5 |
| F6 | Set next normal dice roll to 6 |
| BackQuote (`~ key) | Clear current dice selection |

The selection is valid for 10 seconds and is consumed after one normal dice roll.
If no F1-F6 key is pressed, the plugin does not change dice behavior.

## Speed Keys

Speed boost is enabled by default at x1.8.
The status window is hidden by default.

| Key | Action |
| --- | --- |
| F7 | Decrease speed by 0.25, minimum x1.0 |
| F8 | Increase speed by 0.25, maximum x3.0 |
| F9 | Toggle speed boost on/off |
| F10 | Show/hide the plugin status window |

The speed feature uses Unity `Time.timeScale` and also adjusts `Time.fixedDeltaTime`.
When the plugin is destroyed, it restores `Time.timeScale = 1f` and the original `fixedDeltaTime`.

## Technical Notes

The dice hook remains `BattleBase.GetDice(int staff, ref List<int> ortList)`.
The plugin does not hook `DelCard`, card deletion, per-step movement, remaining-step decrement, or event settlement.

## Logs

If it does not work, send:

`D:\Steam\steamapps\common\Richman11\BepInEx\LogOutput.log`
