using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceMan : IEnemy {

    public void Awake () 
    {
        type = EnemyType.SpaceMan;
        _base.Hp = 150;
        _base.Speed = 1;
    }

    protected override void PlaySound()
    {
       
    }
}
