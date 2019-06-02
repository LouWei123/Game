using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IScene
{
    private string _currentSceneName;
    protected ScenesController _controller;
    public IScene(string sceneName, ScenesController controller)
    {
        _currentSceneName = sceneName;
        _controller = controller;
    }
    public string SceneName
    {
        get { return _currentSceneName; }
    }
    public virtual void SceneStart() { }//场景开始的操作
    public virtual void SceneEnd() { }//场景结束的操作
    public virtual void SceneUpdate() { }//场景的Update操作
}
