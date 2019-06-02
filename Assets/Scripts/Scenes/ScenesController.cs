using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController
{
    private IScene _currentScene;
    private AsyncOperation _asycOper;
    private bool StartScene = false;
    public void SetScene(IScene scene, bool isLoadScene = true)
    {
        if (_currentScene != null)
        {
            _currentScene.SceneEnd();
        }
        _currentScene = scene;
        if (isLoadScene)
        {
            Debug.Log(_currentScene.SceneName);
            _asycOper = SceneManager.LoadSceneAsync(_currentScene.SceneName);
            StartScene = false;
        }
        else
        {
            _currentScene.SceneStart();
            StartScene = true;
        }
    }
    public void SceneUpdate()
    {
        if (_asycOper != null && _asycOper.isDone == false) return;

        if (StartScene == false && _asycOper != null && _asycOper.isDone == true)
        {
            _currentScene.SceneStart();
            StartScene = true;
        }

        if (_currentScene != null)
        {
            _currentScene.SceneUpdate();
        }
    }
}
