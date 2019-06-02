using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour {

    #region 字段属性
    public static bool isGameOver = false;
    private static int _energy;
    private static Text energyText;
    public static Text EnergyText
    {
        get
        {
            if (energyText == null)
                energyText = GameObject.Find("EnergyText").GetComponent<Text>();
            return energyText;
        }
    }

    private static GameObject winUI;
    private static GameObject failUI;
    public static GameObject WinUI
    {
        get
        {
            if (winUI == null)
                winUI = GameObject.Find("WinUI").gameObject;
            return winUI;
        }
    }
    public static GameObject FailUI
    {
        get
        {
            if (failUI == null)
                failUI = GameObject.Find("FailUI").gameObject;
            return failUI;
        }
    }

    public static int Energy
    {
        get
        {
            return _energy;
        }
    }
    #endregion
    private void Awake()
    {
        Init();
    }
    public static void Init()
    {
        isGameOver = false;
        WinUI.SetActive(false);
        FailUI.SetActive(false);
        _energy = 300;
        EnergyText.text = _energy.ToString();
        ShowEnergy();
    }
    public static bool EnergyIsEnough(int cost)
    {
        if (Energy >= cost)
            return true;
        else
            return false;
    }
    /// <summary>
    /// 增加能量
    /// </summary>
    /// <param name="num"></param>
    public static void AddEnergy(int num)
    {
        _energy += num;
        ShowEnergy();
    }
    /// <summary>
    ///减少能量
    /// </summary>
    /// <param name="num"></param>
    public static void ReduceEnergy(int num)
    {
        _energy -= num;
        ShowEnergy();
    }
    private static void ShowEnergy()
    {
        EnergyText.text = _energy.ToString();
    }
    public static void ShowGameWinUI()
    {
        WinUI.SetActive(true);
        Time.timeScale = 0;
    }
    public static void ShowGameFailUI()
    {
        FailUI.SetActive(true);
        Time.timeScale = 0;
    }



}