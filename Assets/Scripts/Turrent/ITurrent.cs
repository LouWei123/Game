using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class ITurret : MonoBehaviour
{
    public BaseTurretAttr _base;
    public GameObject _gameObject;//预制体
    public TurretType _type;
    public ParticleSystem _particleSys;//特效系统

    protected LineRenderer _line;
    protected Light _light;

    private float timer = 0;
    public GameObject bulletPrefab;//子弹
    public Transform firePosition;
    public Transform head;
    public LineRenderer laserRenderer;

    public GameObject laserEffect;

    public bool useLaser = false;

    public List<GameObject> Enemys = new List<GameObject>();

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            Enemys.Add(col.gameObject);
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Enemy")
        {
            Enemys.Remove(col.gameObject);
        }
    }

    public int UpLevelCost
    {
        get
        {
            return _base.Cost * (_base.Level / 2 + 1);
        }
    }

    private void Awake()
    {
        Transform effect = _gameObject.transform.Find("Effect");
        _particleSys = effect.GetComponent<ParticleSystem>();
        _line = effect.GetComponent<LineRenderer>();
        _light = effect.GetComponent<Light>();
       // _audio = effect.GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (Enemys.Count > 0 && Enemys[0] != null)
        {
            Vector3 targetPosition = Enemys[0].transform.position;
            targetPosition.y = head.position.y;
            head.LookAt(targetPosition);
        }
        if (useLaser == false)
        {
            timer += Time.deltaTime;
            if (Enemys.Count > 0 && timer >= _base.AtkRateTime)
            {
                timer = 0;
                Attack();
            }
        }
        else if (Enemys.Count > 0)
        {
            if (laserRenderer.enabled == false)
                laserRenderer.enabled = true;
            laserEffect.SetActive(true);
            if (Enemys[0] == null)
            {
                UpdateEnemys();
            }
            if (Enemys.Count > 0)
            {
                laserRenderer.SetPositions(new Vector3[] { firePosition.position, Enemys[0].transform.position });
                Enemys[0].GetComponent<IEnemy>().TakeDamage(_base.Atk * Time.deltaTime);
                laserEffect.transform.position = Enemys[0].transform.position;
                Vector3 pos = transform.position;
                pos.y = Enemys[0].transform.position.y;
                laserEffect.transform.LookAt(pos);
            }
        }
        else
        {
            laserEffect.SetActive(false);
            laserRenderer.enabled = false;
        }
    }

    void Attack()
    {
        if (Enemys[0] == null)
        {
            UpdateEnemys();
        }
        if (Enemys.Count > 0)
        {
            GameObject bullet = GameObject.Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
            bullet.GetComponent<Bullet>().SetTarget(Enemys[0].transform);
        }
        else
        {
            timer = _base.AtkRateTime;
        }
    }

    private void UpdateEnemys()
    {
        List<int> emptyIndex = new List<int>();
        for (int index = 0; index < Enemys.Count; index++)
        {
            if (Enemys[index] == null)
            {
                emptyIndex.Add(index);
            }
        }

        for (int i = 0; i < emptyIndex.Count; i++)
        {
            Enemys.RemoveAt(emptyIndex[i] - i);
        }
    }

    public abstract void ShowUpGradeEffect();

    protected abstract void PlaySound();

}