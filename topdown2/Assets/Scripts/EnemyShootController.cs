using System.Collections;
using System.Collections.Generic;
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
        if (isAiming)
        {
            firePoint.LookAt(_player);
        }

        Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
    }
}
