using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct BaseEnemyArr
{
    #region 字段
    private int _speed;//速度
    private float _hp;//血量
    #endregion

    #region 属性

    public int Speed
    {
        get
        {
            return _speed;
        }
        set
        {
            _speed = value;
        }
    }//速度
    public float Hp
    {
        get
        {
            return _hp;
        }

        set
        {
            _hp = value;
        }
    }//血量

    #endregion
}
public enum EnemyType
{
    SpaceMan,
    SwiftEnemy,
    DefensiveEnemy,
    Boss
}
