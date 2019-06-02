using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPoint : MonoBehaviour {

    public GameObject _turretGo;
    public ITurret _currentTurret;
    public GameObject _buildEffect;
    public int _cost;

	public void BuildTurret(TurretType type)
    {
        _turretGo = FactoryManager.TurretFactory.CreateTurret(type, transform);

        _currentTurret = _turretGo.GetComponent<ITurret>();

        _cost += _currentTurret._base.Cost;
        //GameObject effect = FactoryManager.AssetFactory.LoadEffect("");
        //Destroy(effect, 1.5f);
    }

    public void UpGradeTurret()
    {
        if (_currentTurret._base.Level <= 3)
        {
            if (Game_Manager.EnergyIsEnough(_currentTurret._base.Cost))
            {
                _cost += _currentTurret._base.Cost;
                Game_Manager.ReduceEnergy(_cost);
                _currentTurret._base.Level += 1;
                _currentTurret.ShowUpGradeEffect();
            }
            else
            {
                //能量不足，无法升级
            }
        }
        else
        {
            //已经达到最大等级，不能提升
        }
        
    }

    public void RemoveTurret()
    {
        _turretGo = null;
        _currentTurret = null;
        Game_Manager.AddEnergy(_cost/2);
    }
}

