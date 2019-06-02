using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScene : IScene
{
    public UIScene( ScenesController controller) : base("UIScene", controller) { }

    private Button SrartBtn;
    private Button ExitBtn;

    public override void SceneStart()
    {
        Time.timeScale = 1;

        SrartBtn = GameObject.Find("StartBtn").GetComponent<Button>();
        ExitBtn = GameObject.Find("ExitBtn").GetComponent<Button>();

        SrartBtn.onClick.AddListener(StartGame);
        ExitBtn.onClick.AddListener(ExitGame);
    }

    private void StartGame()
    {
        _controller.SetScene(new GameScene(_controller));
    }
    private void ExitGame()
    {
        Application.Quit();
    }

}
