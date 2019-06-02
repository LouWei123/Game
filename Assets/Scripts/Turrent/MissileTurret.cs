using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTurret : ITurret
{
    private void Awake()
    {

        _type = TurretType.MissileTurret;
        _base.Cost = 90;
        _base.Atk = 90;
        _base.AtkRateTime = 1;
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