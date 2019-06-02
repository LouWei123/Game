using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    private ScenesController controller = null;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        controller = new ScenesController();
        controller.SetScene(new StartScene(controller), false);
    }
    void Update()
    {
        if (controller != null)
            controller.SceneUpdate();
    }
}
