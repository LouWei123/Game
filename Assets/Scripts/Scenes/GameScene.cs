using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class GameScene : IScene
{
    public GameScene( ScenesController controller) : base("GameScene", controller) { }
    /// <summary>
    /// 游戏初始化
    /// </summary>
    public override void SceneStart()
    {
        Game_Manager.Init();
    }
    /// <summary>
    /// 检测游戏时候结束
    /// 结束时返回UI场景
    /// </summary>
    public override void SceneUpdate()
    {
        if (Game_Manager.isGameOver)
        {
            _controller.SetScene(new UIScene(_controller));
        }
    }
}
