using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public abstract class IEnemy : MonoBehaviour
{
    public EnemyType type;
    protected BaseEnemyArr _base;
    public GameObject _gameObject;
    public GameObject EnemyHpGo;
    private GameObject HPRoot;
    public Transform HpTarget;
    protected Slider _hpSlider;
    protected RectTransform _rectTrans;
    private float MaxHP;
    public GameObject explosionEffect;
    protected AudioSource _audio;
    protected Transform[] _positions;
    protected int index = 0;
    protected bool _isDie = false;

    protected float _effectDisplayTime = 0;
    private GameObject go;
    void Start()
    {
        _positions = Waypoints.positions;
        MaxHP = _base.Hp;
        HPRoot = GameObject.FindObjectOfType<HpRoot>().gameObject;
        go  = Instantiate(EnemyHpGo, HPRoot.transform);
        _hpSlider = go.GetComponent<Slider>();
        _rectTrans = go.GetComponent<RectTransform>();
    }

    public void Update()
    {
        _rectTrans.position = RectTransformUtility.WorldToScreenPoint(Camera.main, HpTarget.position);
        Move();
    }

    public virtual void TakeDamage(float damage)
    {
        if (_base.Hp <= 0) return;
        _base.Hp -= damage;
        _hpSlider.value = (float)_base.Hp / MaxHP;
        if (_base.Hp <= 0)
        {
            EnemyDie();
        }
    }

    private void EnemyDie()
    {
        GameObject effect = GameObject.Instantiate(explosionEffect, _gameObject.transform.position, _gameObject.transform.rotation);
        GameObject.Destroy(go);
        GameObject.Destroy(effect, 1.5f);
        GameObject.Destroy(_gameObject);
    }

    public virtual void Move()
    {
        if (index > _positions.Length - 1) return;
        _gameObject.transform.LookAt(_positions[index].position);
        _gameObject.transform.Translate(Vector3.forward * Time.deltaTime * _base.Speed);
        if (Vector3.Distance(_positions[index].position, _gameObject.transform.position) < 0.2f)
        {
            index++;
        }
        if (index > _positions.Length - 1)
        {
            ReachDestination();
        }
    }

    protected virtual void ReachDestination()
    {
        GameObject.Destroy(_gameObject);
    }


    protected abstract void PlaySound();

    protected void DoPlaySound(string clipName)
    {
        AudioClip clip = FactoryManager.AssetFactory.LoadAudioClip(clipName);
        _audio.clip = clip;
        _audio.Play();
    }
}