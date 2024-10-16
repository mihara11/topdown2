using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]

public class bullet : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float lifetime;
    private Rigidbody2D _rb;
    private float currLifeTime;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        currLifeTime = lifetime;

        Destroy(gameObject, lifetime);
    }


    //void Update()
    //{
    //    CheckLifeTime();
    //}

    private void FixedUpdate()
    {
        Move();
    }

    //private void CheckLifeTime()
    //{
    //    if(currLifeTime <= 0)
    //    {
    //        Destroy(gameObject);
    //    }
    //    else
    //    {
    //        currLifeTime -= Time.deltaTime;
    //    }
    //}

    private void Move()
    {
        _rb.velocity = transform.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.TryGetComponent(out TopDownController _))
            Destroy(gameObject);
    }
}
