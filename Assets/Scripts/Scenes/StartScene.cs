using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class StartScene : IScene
{
    public StartScene(ScenesController controller) : base("StartScene", controller) { }
    private Image BGImage;
    private float Timer = 2f;

    public override void SceneStart()
    {
        Debug.Log("SceneStart");
        BGImage = GameObject.Find("BGImage").GetComponent<Image>();
        BGImage.color = Color.black;
    }

    public override void SceneUpdate()
    {
        BGImage.color = Color.Lerp(BGImage.color, Color.white, 1f * Time.deltaTime);
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            _controller.SetScene(new UIScene(_controller));
        }
    }

}
