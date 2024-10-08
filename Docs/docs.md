# 文档

- 添加了旗杆, 碰到旗杆算游戏胜利.
- 可以从 json 读取关卡. 关卡的内容都存在 section 里, 每个 section 长度 100.
  布尔值 ground 表示是否有地面, objects 里面放要生成的东西, 坐标都是相对坐标. 大致是这样:
  > -10: 地面最左侧; 90: 地面最右侧.

  想法是将来要实现关卡选择的时候, 传对应关卡的 json 过去就可以.
  
  用文件可能会不太灵活一点, 但如果给每个关卡 / 难度都单弄一个 scene, 后面修改什么都要修改所有 scene, 可能更麻烦.

8/6 晚

- 增加了关卡选择界面, 修改 Resources/Levels/levelSelection.json 即可.
  - TODO 难度选择还没有实现, 我想在点击按钮后跳出一个 popup, 这个 popup 也可以显示一些描述信息和简单的设置.
    事实上如果想要在 popup 中显示所有关卡信息, 也要读取 `levelx_difficulty.json`.
- 关卡的 json 格式: (...主要是 ai 生成的)
  - 名字: `{jsonfilename}_{difficulty}.json`.
  - level 项: levelId 相当于键值吧, levelname 可能之后可以在一些地方显示, description 是该关卡这个难度的一些说明.
    - TODO: 存储关卡是否通过? 几颗心通过? 可能会用到键值.
  - goal 项: 现在没用到. ai 生成的, 我感觉可能有用就留下了... 如果某个关卡通过需要多个目标 (比如得分多少, 多长时间内?) 就会用到.
- LevelSelection 的格式: 存储一个 row 的列表, 可能每个 row 可以围绕某个元素做一些关卡?
  - 比如第一列做教程, 第二列可能引入某个新要素, ...
    每一列都有一个关卡列表
- 改了 LevelDataStructure 的一些名字.

其实我也没太想好, 是一个关卡的所有难度共用相同的地图, 还是每个难度都有单独一张地图.
第一种方法比较节省, 但限制比较大, 就用了后面的方式.
如果想要简单的地图道具多些, 难的地图少些, 大概用后面的方式会好一些.

2024.08.07
修改gamedata类

   public static int shield { get; set; }

添加了新的成员变量shied护盾值，初始为0(在playercontroller里设置)
目前为了测试，护盾初始值为5，当关卡为高Level时建议初始护盾为0

添加了 回血道具红心和护盾道具
回血超过上限的判断逻辑我放在 playerController.Heal()这个函数里了，后续如果要调整血量上限此处需要修改
护盾血量同时存在时先消耗护盾的判断逻辑也在playerController里
添加了碰触护盾道具增加护盾值的函数AddShield

接下来我试着加点场景里的背景图片，以及会动的贴图(比如云彩飞鸟之类的)
不知是Bug还是特性的东西：json不同的section里的坐标似乎不是绝对坐标，而是相对坐标
第一个section里的护盾坐标和第三个section中的护盾坐标都一样，但是实际游戏中的绝对坐标不一样

08.10
增加了可以循环播放的背景，原理是两个一样（且开头和末尾可以拼接）的背景图片循环播放，具体实现见game场景中的background和background2两个对象
08.11
1.增加了新道具bomb，碰到bomb玩家扣除2生命值
2.将初始关卡生命护盾的生成逻辑移动至Json内，简单难度开局6生命值2护盾，困难难度开局4生命值
3.增加了新道具angelheart，碰到angelheart时玩家回复所有生命值
4.制作了关卡1-4，并添加了简略的描述
(关卡4难度有待调整)
08.12
1.加了游戏bgm和碰撞音效，碰撞音效播放逻辑在各个prefeb内部。同时修改了物体遭到碰撞后的逻辑，使用
GetComponent<Collider2D>().enabled = false;  
GetComponent<SpriteRenderer>().enabled = false; 
而不是destroy(),因为后者会导致音频无法播放。
2.减小了Bomb的碰撞面积
2.制作第5关（暂定为最后一关）