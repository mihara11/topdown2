using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]

public class bullet : MonoBehaviour
{
    public float _hp;
    [SerializeField] private float speed;
    [SerializeField] private float lifetime;
    private Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rb.velocity = transform.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject go = GameObject.Find("Box");
        Box_Script boxscript = go.GetComponent<Box_Script>();
        if(!collision.gameObject.TryGetComponent(out TopDownController _) && _hp <=0)
            Destroy(gameObject);
 
        
    }
}
