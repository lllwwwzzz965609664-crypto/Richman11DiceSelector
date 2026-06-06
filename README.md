# 🎲 Richman11 Dice Selector / 大富翁11骰子选择器

<p align="center">
  <b>🎮 A local single-player dice selector mod for Richman11</b><br>
  <b>《大富翁11》本地单机骰子点数选择插件</b>
</p>

<p align="center">
  <img src="https://img.shields.io/badge/Game-Richman11-blue?style=for-the-badge" />
  <img src="https://img.shields.io/badge/Mod-BepInEx%205-green?style=for-the-badge" />
  <img src="https://img.shields.io/badge/Mode-Single%20Player-orange?style=for-the-badge" />
  <img src="https://img.shields.io/badge/Version-v1.1.0-purple?style=for-the-badge" />
</p>

---

## 🌏 Language / 语言

* 🇨🇳 中文说明在前
* 🇬🇧 English description included below each section

---

## 📌 简介 / Introduction

### 🇨🇳 中文

这是一个用于 Steam 单机版《大富翁11 / Richman11》的本地 BepInEx 插件。

它可以让你在单机模式下指定下一次普通骰子的点数，并提供游戏速度调整功能。
适合本地娱乐、测试路线、验证机制、减少重复等待。

> ⚠️ 本插件仅供本地单机使用。
> 请勿用于联机、多人、排行榜、竞技或任何影响其他玩家体验的场景。

### 🇬🇧 English

This is a local BepInEx plugin for the Steam single-player version of **Richman11**.

It allows you to select the next normal dice result and adjust the overall game speed.
Useful for local testing, route checking, mechanic verification, and reducing waiting time.

> ⚠️ This plugin is for local single-player use only.
> Do not use it in online, multiplayer, ranked, competitive, or any scenario that may affect other players.

---

## ✨ 功能特色 / Features

| 🇨🇳 功能                     | 🇬🇧 Feature                                                                  |
| --------------------------- | ----------------------------------------------------------------------------- |
| 🎲 使用 `F1-F6` 设置下一次普通骰子点数   | Use `F1-F6` to set the next normal dice result                                |
| 🧹 使用 `` ` / ~ `` 清空当前骰子选择  | Use `` ` / ~ `` to clear the selected dice value                              |
| ⚡ 默认开启 1.8 倍游戏速度            | Default game speed is set to 1.8x                                             |
| 🐢 `F7` 降速，🚀 `F8` 加速       | `F7` slows down, `F8` speeds up                                               |
| ⏯️ `F9` 开关加速                | `F9` toggles speed control                                                    |
| 👁️ `F10` 显示 / 隐藏状态窗口       | `F10` shows / hides the status overlay                                        |
| ✅ 不占用数字键 `1-6`，避免和游戏卡牌快捷键冲突 | Does not use number keys `1-6`, avoiding conflict with in-game item shortcuts |

---

## 📥 下载 / Download

### 🇨🇳 中文

请前往 Releases 页面下载最新版：

👉 [Download Latest Release](https://github.com/lllwwwzzz965609664-crypto/Richman11DiceSelector/releases/latest)

下载文件：

```text
Richman11DiceSelector.dll
```

### 🇬🇧 English

Go to the Releases page and download the latest version:

👉 [Download Latest Release](https://github.com/lllwwwzzz965609664-crypto/Richman11DiceSelector/releases/latest)

Download this file:

```text
Richman11DiceSelector.dll
```

---

## 🛠️ 安装方法 / Installation

### 🇨🇳 中文

### 1️⃣ 安装 BepInEx 5

本插件需要 **BepInEx 5** 环境。
如果你已经安装过 BepInEx，可以跳过这一步。

### 2️⃣ 放入插件目录

将下载好的：

```text
Richman11DiceSelector.dll
```

放入：

```text
D:\Steam\steamapps\common\Richman11\BepInEx\plugins
```

如果你的 Steam 游戏安装在其他盘，请根据自己的路径调整。

### 3️⃣ 重启游戏

请完全关闭游戏后重新打开。
进入单机模式后即可使用快捷键。

---

### 🇬🇧 English

### 1️⃣ Install BepInEx 5

This plugin requires **BepInEx 5**.
If you already have BepInEx installed, you can skip this step.

### 2️⃣ Put the plugin into the plugins folder

Place:

```text
Richman11DiceSelector.dll
```

into:

```text
D:\Steam\steamapps\common\Richman11\BepInEx\plugins
```

If your Steam library is installed in another location, adjust the path accordingly.

### 3️⃣ Restart the game

Fully close the game and launch it again.
Enter single-player mode and use the hotkeys.

---

## 🎮 快捷键 / Hotkeys

## 🎲 骰子控制 / Dice Control

| 快捷键 / Hotkey | 🇨🇳 作用       | 🇬🇧 Action                      |
| ------------ | ------------- | -------------------------------- |
| `F1`         | 下一次普通骰子点数设为 1 | Set next normal dice result to 1 |
| `F2`         | 下一次普通骰子点数设为 2 | Set next normal dice result to 2 |
| `F3`         | 下一次普通骰子点数设为 3 | Set next normal dice result to 3 |
| `F4`         | 下一次普通骰子点数设为 4 | Set next normal dice result to 4 |
| `F5`         | 下一次普通骰子点数设为 5 | Set next normal dice result to 5 |
| `F6`         | 下一次普通骰子点数设为 6 | Set next normal dice result to 6 |
| `` ` / ~ ``  | 清空当前骰子选择      | Clear selected dice value        |

### 📎 说明 / Notes

* ✅ 设置点数后，会在下一次普通掷骰时生效。
  The selected value takes effect on the next normal dice roll.

* ⏱️ 点数选择有效时间为 10 秒。
  The selected dice value is valid for 10 seconds.

* 🔄 成功生效一次后会自动清空。
  It will be cleared automatically after one successful use.

* 🎲 如果没有按 `F1-F6`，插件不会改变骰子结果。
  If you do not press `F1-F6`, the plugin will not change the dice result.

* 🚫 本插件不再使用数字键 `1-6`，避免和游戏内卡牌快捷键冲突。
  This plugin no longer uses number keys `1-6`, avoiding conflict with in-game item shortcuts.

---

## ⚡ 速度控制 / Speed Control

默认开启 **1.8x** 游戏速度。
Default game speed is **1.8x**.

| 快捷键 / Hotkey | 🇨🇳 作用               | 🇬🇧 Action                          |
| ------------ | --------------------- | ------------------------------------ |
| `F7`         | 降低速度，每次 -0.25，最低 1.0x | Decrease speed by 0.25, minimum 1.0x |
| `F8`         | 提高速度，每次 +0.25，最高 3.0x | Increase speed by 0.25, maximum 3.0x |
| `F9`         | 开启 / 关闭加速             | Toggle speed control on / off        |
| `F10`        | 显示 / 隐藏插件状态窗口         | Show / hide plugin status overlay    |

### ⚠️ 速度建议 / Speed Advice

🇨🇳 建议速度保持在 **1.5x - 2.0x** 之间。
速度过高可能导致动画、移动、事件结算出现异常。

🇬🇧 Recommended speed: **1.5x - 2.0x**.
Very high speed may cause animation, movement, or event timing issues.

---

## 🖥️ 状态窗口 / Status Overlay

### 🇨🇳 中文

状态窗口默认隐藏，不会遮挡游戏画面。

按 `F10` 可以显示或隐藏状态窗口。
状态窗口只负责显示当前状态，不是插件开关。

隐藏窗口后，以下功能仍然正常生效：

* `F1-F6` 设置骰子点数
* `` ` / ~ `` 清空骰子选择
* `F7 / F8 / F9` 控制速度
* `F10` 重新显示窗口

### 🇬🇧 English

The status overlay is hidden by default and will not block the game screen.

Press `F10` to show or hide the overlay.
The overlay only displays current status. It is not the plugin switch.

Even when the overlay is hidden, these features still work:

* `F1-F6` set dice value
* `` ` / ~ `` clears selected dice value
* `F7 / F8 / F9` control speed
* `F10` shows the overlay again

---

## ❓ 常见问题 / FAQ

### Q1：为什么不用数字键 1-6？

### Q1: Why not use number keys 1-6?

🇨🇳 因为《大富翁11》本身会使用数字键 `1-6` 作为卡牌道具快捷键。
如果插件也监听数字键，就会出现选择骰子时误触卡牌的问题。

所以新版改成了 `F1-F6`。

🇬🇧 Richman11 already uses number keys `1-6` as item/card shortcuts.
If the plugin also listens to those keys, selecting dice values may accidentally trigger in-game cards.

That is why the new version uses `F1-F6`.

---

### Q2：隐藏状态窗口后，插件还有效吗？

### Q2: Does the plugin still work when the overlay is hidden?

🇨🇳 有效。
状态窗口只是显示当前状态，不是插件开关。

🇬🇧 Yes.
The overlay only displays plugin status. It does not enable or disable the plugin.

---

### Q3：按了 F1-F6 没反应怎么办？

### Q3: What should I do if F1-F6 does not work?

请检查 / Please check:

1. 是否已经安装 BepInEx 5
   Whether BepInEx 5 is installed

2. DLL 是否放在正确目录
   Whether the DLL is placed in the correct folder

```text
D:\Steam\steamapps\common\Richman11\BepInEx\plugins
```

3. 是否完全关闭游戏后重新启动
   Whether the game was fully restarted

4. 是否进入的是单机模式
   Whether you are in single-player mode

5. 是否在 10 秒内进行了普通掷骰
   Whether you rolled a normal dice within 10 seconds

---

### Q4：游戏速度太快怎么办？

### Q4: What if the game speed is too fast?

🇨🇳 按 `F7` 降低速度。
按 `F9` 可以关闭加速。

🇬🇧 Press `F7` to decrease speed.
Press `F9` to disable speed control.

---

## 🧪 技术说明 / Technical Notes

| 项目 / Item        | 内容 / Detail                                            |
| ---------------- | ------------------------------------------------------ |
| Mod Loader       | BepInEx 5                                              |
| Patch Library    | Harmony                                                |
| Game             | Richman11 / 大富翁11                                      |
| Mode             | Local Single Player                                    |
| Language         | C#                                                     |
| Dice Hook Target | `BattleBase.GetDice(int staff, ref List<int> ortList)` |
| Speed Control    | Unity `Time.timeScale` + `Time.fixedDeltaTime`         |

### 🇨🇳 中文

插件不会 Hook：

* 卡牌删除
* 步数扣减
* 地图事件结算
* Steam 账号
* 网络通信
* 联机行为

### 🇬🇧 English

This plugin does not hook:

* Card deletion
* Step deduction
* Map event settlement
* Steam account behavior
* Network communication
* Online multiplayer behavior

---

## 📄 日志排查 / Log Troubleshooting

如果插件不生效，可以查看 BepInEx 日志：

If the plugin does not work, check the BepInEx log:

```text
D:\Steam\steamapps\common\Richman11\BepInEx\LogOutput.log
```

反馈问题时，建议说明以下信息：

When reporting an issue, please include:

* 游戏版本 / Game version
* BepInEx 是否正常启动 / Whether BepInEx starts correctly
* 插件 DLL 放置路径 / Plugin DLL path
* 按下的快捷键 / Hotkey pressed
* 是否进入单机模式 / Whether you are in single-player mode

---

## 📦 版本更新 / Changelog

### v1.1.0

* 🎲 骰子点数快捷键从 `1-6` 改为 `F1-F6`
* 🧹 清空选择改为 `` ` / ~ ``
* ⚡ 新增默认 1.8x 游戏速度
* 🐢 `F7` 降速，🚀 `F8` 加速，⏯️ `F9` 开关加速
* 👁️ 状态窗口默认隐藏，`F10` 显示 / 隐藏
* ✅ 避免和游戏内卡牌快捷键冲突

### v1.0.0

* 🎲 初始版本
* ✅ 支持设置下一次普通骰子点数

---

## ⚖️ License / 许可证

本项目使用 MIT License。
This project is licensed under the MIT License.

---

## ⚠️ 免责声明 / Disclaimer

### 🇨🇳 中文

本插件仅用于本地单机测试与娱乐。
请勿用于联机模式、多人对战、排行榜、竞技、商业用途或任何影响其他玩家体验的场景。
使用本插件造成的任何后果由使用者自行承担。

### 🇬🇧 English

This plugin is intended for local single-player testing and entertainment only.
Do not use it in online mode, multiplayer mode, ranked mode, competitive mode, commercial use, or any situation that may affect other players.
Any consequences caused by using this plugin are the user's own responsibility.
