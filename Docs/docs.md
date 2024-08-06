# 文档

- 添加了旗杆, 碰到旗杆算游戏胜利.
- 可以从 json 读取关卡. 关卡的内容都存在 section 里, 每个 section 长度 100.
  布尔值 ground 表示是否有地面, objects 里面放要生成的东西, 坐标都是相对坐标. 大致是这样:
  > -10: 地面最左侧; 90: 地面最右侧.

  想法是将来要实现关卡选择的时候, 传对应关卡的 json 过去就可以.
  
  用文件可能会不太灵活一点, 但如果给每个关卡 / 难度都单弄一个 scene, 后面修改什么都要修改所有 scene, 可能更麻烦.

8/6 晚

- 增加了关卡选择界面, 修改 Resources/Levels/levelSelection.json 即可.
  - 难度选择还没有实现, 我想在点击按钮后跳出一个 popup, 这个 popup 也可以显示一些描述信息和简单的设置.
- 描述关卡的 json 格式: 这是 ai 生成之后我又改的（
  - 名字: `{jsonfilename}_{difficulty}.json`.
  - level 项: levelId 相当于键值吧, levelname 可能之后可以在一些地方显示. 其他没啥好说明的吧
- 改了 LevelDataStructure 的一些名字.
