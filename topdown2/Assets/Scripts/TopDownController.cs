using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

[RequireComponent(typeof(Rigidbody2D))]
public class TopDownController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject bulletprefab;
    [SerializeField] private Transform firepoint;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;
        _rb.velocity = moveDirection * speed;
    }
    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Instantiate(bulletprefab, firepoint.position, transform.rotation);

        }
    }
}
