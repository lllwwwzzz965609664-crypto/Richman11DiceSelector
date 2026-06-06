# 🎲 Richman11 骰子选择器 / Richman11 Dice Selector

![BepInEx](https://img.shields.io/badge/BepInEx-5.x-blue)
![Game](https://img.shields.io/badge/Game-Richman11-orange)
![Mode](https://img.shields.io/badge/Mode-Local%20Single--Player-green)
![License](https://img.shields.io/badge/License-MIT-lightgrey)

一个为 **《大富翁11 / Richman11》** 制作的本地单机骰子选择插件。
A local single-player dice selector plugin for **Richman11**, powered by **BepInEx 5 + Harmony**.

> ⚠️ 仅供本地单机娱乐与测试使用。
> ⚠️ For local single-player use only.

---

## ✨ 功能 / Features

* 🎯 按下 `1 ~ 6`，设置下一次普通掷骰点数
  Press `1 ~ 6` to set the next normal dice result.

* 🧹 按下 `0`，清空当前选择
  Press `0` to clear the selected dice point.

* 🔁 点数只生效一次，掷骰后自动清空
  The selected dice point is consumed once after rolling.

* 🖥️ 支持主键盘数字键，无需小键盘
  Supports top-row number keys. Numpad is not required.

* 🚫 不支持在线模式
  Online mode is not supported.

---

## 📦 下载 / Download

请在右侧 **Releases / 发行作品** 中下载：

Please download from **Releases**:

```text
Richman11DiceSelector.dll
```

不要下载整个源码包来安装，普通玩家只需要 `.dll` 文件。
Normal users only need the `.dll` file, not the source code package.

---

## 🧩 安装 / Installation

### 1. 安装 BepInEx 5 x64

把 **BepInEx 5 x64** 解压到《大富翁11》的游戏根目录，也就是 `richman11.exe` 所在目录。

Extract **BepInEx 5 x64** into the Richman11 game folder where `richman11.exe` is located.

目录结构应类似：

The folder should look like this:

```text
Richman11
├─ BepInEx
├─ doorstop_config.ini
├─ winhttp.dll
├─ richman11.exe
├─ richman11_Data
└─ UnityPlayer.dll
```

首次安装 BepInEx 后，建议先启动一次游戏，然后退出。
After installing BepInEx, start the game once and then close it.

---

### 2. 放入插件 / Install the plugin

把下载到的：

Put the downloaded file:

```text
Richman11DiceSelector.dll
```

放入：

into:

```text
Richman11\BepInEx\plugins
```

最终结构应类似：

Final structure:

```text
Richman11
└─ BepInEx
   └─ plugins
      └─ Richman11DiceSelector.dll
```

---

## 🎮 使用方法 / How to Use

1. 进入本地单机游戏
   Start a local single-player game.

2. 轮到你点击 `GO` 前，按 `1 ~ 6`
   Before clicking `GO`, press `1 ~ 6`.

3. 屏幕左上角窗口会显示下一次骰子点数
   The overlay window will show the selected next dice point.

4. 点击 `GO` 掷骰
   Click `GO` to roll.

5. 本次点数生效后会自动清空
   The selected point will be cleared automatically after one use.

示例：

Example:

```text
按 6 → 点击 GO → 下一次普通骰子结果为 6
Press 6 → Click GO → The next normal dice result becomes 6
```

---

## ⌨️ 按键 / Hotkeys

| 按键 / Key | 功能 / Action              |
| -------- | ------------------------ |
| `1`      | 下一次骰子为 1 / Next dice = 1 |
| `2`      | 下一次骰子为 2 / Next dice = 2 |
| `3`      | 下一次骰子为 3 / Next dice = 3 |
| `4`      | 下一次骰子为 4 / Next dice = 4 |
| `5`      | 下一次骰子为 5 / Next dice = 5 |
| `6`      | 下一次骰子为 6 / Next dice = 6 |
| `0`      | 清空选择 / Clear selection   |

---

## 🛡️ 设计说明 / Design Notes

本插件只 hook 普通骰子结果相关方法：

This plugin only hooks the normal dice result method:

```text
BattleBase.GetDice(...)
```

它不会：

It does not:

* ❌ hook `DelCard`
* ❌ 拦截卡牌删除 / intercept card removal
* ❌ 修改卡牌消耗逻辑 / modify card consumption
* ❌ hook 人物逐步移动 / hook step-by-step character movement
* ❌ 修改事件结算流程 / modify event resolution

这样可以尽量避免人物移动、事件触发、回合推进被卡住。
This design helps avoid freezing character movement, event triggers, or turn progression.

---

## 🧪 测试环境 / Tested Environment

* 🎮 Richman11 Steam version
* 🧩 BepInEx 5 x64
* 🪟 Windows 10 / Windows 11

如果游戏更新后插件失效，可能是游戏内部方法发生变化。
If the plugin stops working after a game update, the internal game method may have changed.

---

## 🧾 日志 / Logs

插件日志会写入：

Plugin logs are written to:

```text
Richman11\BepInEx\LogOutput.log
```

如果插件无效，请检查日志中是否出现类似内容：

If the plugin does not work, check whether the log contains something like:

```text
Richman11DiceSelector loaded successfully.
Hooked dice method: BattleBase.GetDice(...)
Actually override next normal dice result with: 6
```

---

## ⚠️ 声明 / Disclaimer

本项目为非官方本地单机插件，与游戏官方无关。
This is an unofficial local single-player plugin and is not affiliated with the official game developers.

请勿用于在线模式、联机对局或任何破坏他人游戏体验的场景。
Do not use it in online mode, multiplayer matches, or any situation that affects other players.

使用本插件产生的风险由使用者自行承担。
Use at your own risk.

---

## 📄 License

This project is licensed under the MIT License.
