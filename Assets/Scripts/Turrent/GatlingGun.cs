using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlingGun :  ITurret
{
    private void Awake()
    {
        _type = TurretType.GatlingGun;
        _base.Cost = 70;
        _base.Atk = 70;
        _base.AtkRateTime = 100;
    }

    public override void ShowUpGradeEffect()
    {
        throw new System.NotImplementedException();
    }

    protected override void PlaySound()
    {
        throw new System.NotImplementedException();
    }
}





