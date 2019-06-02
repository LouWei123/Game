using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build_Manager : MonoBehaviour {

    public TurretData laserTurretData;
    public TurretData missileTurretData;
    public TurretData gatlingTurretData;

    //表示当前选择的炮台(要建造的炮台)
    private TurretData selectedTurretData;
    //表示当前选择的炮台(场景中的游戏物体)
    private TurretPoint selectedTurretPoint;

    public GameObject upgradeCanvas;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {//判断是否是点击事件
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, LayerMask.GetMask("TurretPoint")))
            {
                print("2222");
                TurretPoint tp = hitInfo.collider.GetComponent<TurretPoint>();
                print(selectedTurretData != null);
                print(selectedTurretData.type);
                print(tp._turretGo == null);
                if (selectedTurretData != null && tp._turretGo == null)
                {
                    print(selectedTurretData.Cost);
                    print(Game_Manager.EnergyIsEnough(selectedTurretData.Cost));
                    //可以创建 
                    if (Game_Manager.EnergyIsEnough(selectedTurretData.Cost))
                    {
                        Game_Manager.ReduceEnergy(selectedTurretData.Cost);
                        tp.BuildTurret(selectedTurretData.type);
                    }
                    else
                    {
                        //提示钱不够

                    }
                }
                else if (tp._turretGo != null)
                {
                    if (tp == selectedTurretPoint && upgradeCanvas.activeInHierarchy)
                    {
                        HideUpgradeUI();
                    }
                    else
                    {
                        ShowUpgradeUI();
                    }
                    selectedTurretPoint = tp;
                }
                //如果是一根手指触摸屏幕而且是刚开始触摸屏幕 
                if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    if (Input.GetTouch(0).tapCount == 1)
                    {//判断点击的次数
                        print("1111111111111111111111111");
                        
                    }
                }
            }
        }
    }

    private void ShowUpgradeUI()
    {
        upgradeCanvas.SetActive(true);
    }

    private void HideUpgradeUI()
    {
        upgradeCanvas.SetActive(false);
    }
    public void OnUpgradeButtonDown()
    {
        if (Game_Manager.EnergyIsEnough(selectedTurretPoint._currentTurret.UpLevelCost))
        {
            Game_Manager.ReduceEnergy(selectedTurretPoint._currentTurret.UpLevelCost);
            selectedTurretPoint.UpGradeTurret();
        }
        else
        {
            //能量不足
        }

        HideUpgradeUI();
    }
    public void OnDestroyButtonDown()
    {
        selectedTurretPoint.RemoveTurret();
        HideUpgradeUI();
    }

    public void OnLaserSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = laserTurretData;

        }
    }

    public void OnMissileSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = missileTurretData;
        }
    }
    public void OnGatlingGunSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = gatlingTurretData;
        }
    }
}
[System.Serializable]
public class TurretData
{
    private int cost;
    public TurretType type;

    public int Cost
    {
        get
        {
            if (type == TurretType.GatlingGun)
                cost = 70;
            if (type == TurretType.LaserTurret)
                cost = 80;
            if (type == TurretType.MissileTurret)
                cost = 90;
            return cost;
        }

    }

    public  TurretData()
    {

    }
}
