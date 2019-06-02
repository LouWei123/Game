using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class FactoryManager
{
    private static IAssetFactory assetFactory = null;
    private static IEnemyFactory enemyFactory = null;
    private static ITurretFactory turretFactory = null;

    public static IAssetFactory AssetFactory
    {
        get
        {
            if (assetFactory == null)
            {
                assetFactory = new AssetFactory();
            }
            return assetFactory;

        }
    }
    public static IEnemyFactory EnemyFactory
    {
        get
        {
            if (enemyFactory == null)
            {
                enemyFactory = new EnemyFactory();
            }
            return enemyFactory;
        }
    }
    public static ITurretFactory TurretFactory
    {
        get
        {
            if (turretFactory == null)
            {
                turretFactory = new TurretFactory();
            }
            return turretFactory;
        }

    }
}

# region Factory接口
public interface IAssetFactory
{
    AudioClip LoadAudioClip(string name);

    GameObject LoadEffect(string name);

    GameObject LoadEnemy(string name);

    Sprite LoadSprite(string name);

    GameObject LoadTurret(string name);
}

public interface IAttrFactory
{
    BaseTurretAttr GetTurretBaseArr(TurretType turretType);
}

public interface IEnemyFactory
{
    GameObject CreateEnemy(EnemyType enemyType, Transform buildPosition,int lv );

}

public interface ITurretFactory
{
    GameObject CreateTurret(TurretType turretType,Transform transform);
}
# endregion

# region Factory具体实现

public class AssetFactory : IAssetFactory
{
    public const string EnemyPath = "Enemy/";
    public const string TurretPath = "Turret/";
    public const string EffectPath = "Effect/";
    public const string AudioPath = "Audio/";
    public const string SpritePath = "Sprite/";

    public GameObject LoadEffect(string name)
    {
        return InstantiateGameObject(EffectPath + name);
    }

    public AudioClip LoadAudioClip(string name)
    {
        return Resources.Load(SpritePath + name, typeof(AudioClip)) as AudioClip;
    }

    public Sprite LoadSprite(string name)
    {
        return Resources.Load(SpritePath + name, typeof(Sprite)) as Sprite;
    }

    private GameObject InstantiateGameObject(string path)
    {
        UnityEngine.Object o = Resources.Load(path);
        if (o == null)
        {
            Debug.LogError("无法加载资源，路径:" + path); return null;
        }
        return UnityEngine.GameObject.Instantiate(o) as GameObject;
    }

    public GameObject LoadTurret(string name)
    {
        return InstantiateGameObject(TurretPath + name);
    }

    public GameObject LoadEnemy(string name)
    {
        return InstantiateGameObject(EnemyPath + name);
    }
}
public class EnemyFactory : IEnemyFactory
{
    public GameObject CreateEnemy(EnemyType enemyType, Transform buildPosition, int lv)
    {
        Debug.Log("CreateEnemy");
        GameObject go =new GameObject() ;

        if (enemyType == EnemyType.SpaceMan)
            go = FactoryManager.AssetFactory.LoadEnemy("SpaceMan");
        if (enemyType == EnemyType.SwiftEnemy)
            go = FactoryManager.AssetFactory.LoadEnemy("SwiftEnemy");
        if (enemyType == EnemyType.DefensiveEnemy)
            go = FactoryManager.AssetFactory.LoadEnemy("DefensiveEnemy");
        if (enemyType == EnemyType.Boss)
            go = FactoryManager.AssetFactory.LoadEnemy("Boss");
        go.transform.position = buildPosition.position;
        go.transform.parent = buildPosition;

        return go;
    }
}

public class TurretFactory : ITurretFactory
{
    public GameObject CreateTurret(TurretType turretType, Transform buildPosition)
    {
        GameObject go = new GameObject();
        if (turretType == TurretType.GatlingGun)
            go = FactoryManager.AssetFactory.LoadTurret("GatelingGun");
        if (turretType == TurretType.LaserTurret)
            go = FactoryManager.AssetFactory.LoadTurret("LaserTurret");
        if (turretType == TurretType.MissileTurret)
            go = FactoryManager.AssetFactory.LoadTurret("MissileTurret");

        go.transform.position = new Vector3( buildPosition.position.x, buildPosition.position.y+1f, buildPosition.position.z);
        go.transform.parent = buildPosition;

        return go;
    }
}
#endregion
