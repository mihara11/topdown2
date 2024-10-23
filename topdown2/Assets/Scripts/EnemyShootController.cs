using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyShootController : MonoBehaviour
{

    private float _currTimer;
    [SerializeField] private float shootDelay;
    [SerializeField] private bool isAiming;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    private Transform _player;
    void Start()
    {
        _currTimer = shootDelay;
        _player = FindObjectOfType<TopDownController>().gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        DelayShoot();
    }

    private void DelayShoot()
    {
        if(_currTimer > 0)
        {
            _currTimer -= Time.deltaTime;
        }
        else
        {
            Shoot();
            _currTimer = shootDelay;
        }
    }
    private void Shoot()
    {
        Quaternion bulletrotation = firePoint.rotation;
        if (isAiming)
        {
            Vector2 direction = _player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x)* Mathf.Rad2Deg;
            bulletrotation = Quaternion.Euler(new Vector3(0, 0, angle - 90f));
        }

        Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
    }
}
