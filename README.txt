Richman11DiceSelector
=====================

用途：
本插件是 BepInEx 5 + Harmony 插件，只用于 Steam 单机游戏《大富翁11 / Richman11》的本地单机测试。
不要用于联机模式；插件不会绕过 Steam，不处理账号、网络或反作弊相关内容。

安装：
把 Richman11DiceSelector.dll 放到：
\Steam\steamapps\common\Richman11\BepInEx\plugins

使用：
1. 进入本地单机游戏。
2. 按数字键 1、2、3、4、5、6，设置下一次普通掷骰点数。
3. 按 0 清空当前选择。
4. 选择只保留 10 秒；下一次普通掷骰覆盖一次后会自动清空。
5. 如果没有按 1-6，插件不改游戏逻辑。

技术说明：
插件 hook 的是 BattleBase.GetDice(int staff, ref List<int> ortList)，也就是普通骰子路径生成逻辑。
它不会 hook DelCard，不会拦截卡牌删除，不会 hook 人物每一步移动、剩余步数递减或事件结算。

日志：
BepInEx\LogOutput.log 会记录插件加载、hook 方法、用户设置的点数、实际覆盖的点数。
如果无效，请把 \Steam\steamapps\common\Richman11\BepInEx\LogOutput.log 发回来继续分析。
