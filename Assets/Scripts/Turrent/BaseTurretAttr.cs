using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct BaseTurretAttr 
{
    private int _atk;
    private float _atkRange;
    private float _atkRateTime;
    private int _cost;
    private int _level;

    public int Atk { get { return _atk; }  set { value = _atk; } }
    public float AtkRange { get { return _atkRange; } set { value = _atkRange; } }
    public float AtkRateTime { get { return _atkRateTime; } set { value = _atkRateTime; } }
    public int Cost { get { return _cost; }  set { _cost = value; } }
    public int Level { get { return _level; } set { _level = value; } }
}



public enum TurretType
{
    GatlingGun,
    LaserTurret,
    MissileTurret,
}
