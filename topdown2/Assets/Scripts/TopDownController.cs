using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting.APIUpdating;
using static UnityEditor.Experimental.GraphView.GraphView;

[RequireComponent(typeof(Rigidbody2D))]
public class TopDownController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject bulletprefab;
    [SerializeField] private Transform firepoint;
    [SerializeField] private LayerMask damagelayerMask;
    [SerializeField] private Camera _mainCamera;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Shoot();
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
            Vector3 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            Vector2 direction = mousePosition - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion bulletrotation = Quaternion.Euler(new Vector3(0, 0, angle - 90f));
            Instantiate(bulletprefab, firepoint.position, firepoint.rotation);
            Debug.Log("Shoot");

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMaskUtil.ContainsLayer(damagelayerMask, collision.gameObject))
        { 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);    
        }
    }
}
