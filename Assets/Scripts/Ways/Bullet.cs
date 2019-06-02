using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int _damage = 50;

    public float _speed = 20;

    public GameObject explosionEffectPrefab;

    private float _distanceArriveTarget = 1.2f;

    private Transform _target;

    public void SetTarget(Transform _target)
    {
        this._target = _target;
    }

    void Update()
    {
        if (_target == null)
        {
            EnemyDie();
            return;
        }

        transform.LookAt(_target.position);
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);

        Vector3 dir = _target.position - transform.position;
        if (dir.magnitude < _distanceArriveTarget)
        {
            _target.GetComponent<IEnemy>().TakeDamage(_damage);
            EnemyDie();   
        }
    }

    void EnemyDie()
    {
        //GameObject effect = GameObject.Instantiate(explosionEffectPrefab, transform.position, transform.rotation);
        //Destroy(effect, 1);
        Destroy(this.gameObject);
    }

}
