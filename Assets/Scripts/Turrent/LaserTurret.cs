using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : ITurret
{
    private void Awake()
    {
        _type = TurretType.LaserTurret;
        _base.Cost = 80;
        _base.Atk = 70;
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
