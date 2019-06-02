using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public GameObject StopPanel;

    private void Awake()
    {
        StopPanel.SetActive(false);
    }
    public void ShowStopPanel()
    {
        StopPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void HideStopPanel()
    {
        StopPanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void Exit()
    {
        Game_Manager.isGameOver = true;
    }


}
