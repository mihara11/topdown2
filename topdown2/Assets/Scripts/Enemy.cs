using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Rigidbody2D))]
public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float speed;

    //[SerializeField] private float minFollowDistance;
    private Rigidbody2D _rb;
    private Transform _followtarget;

    private bool _isCollided;

    
    void Update()
    {
        FollowPlayer();
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out TopDownController _))
        {
            _isCollided = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out TopDownController _))
        {
            _isCollided = false;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out TopDownController _))
        {
            _followtarget = collision.transform;
        }
    }

    private void FollowPlayer()
    {
        //float distance = Vector2.Distance(transform.position, _followtarget.position);
        if(_followtarget && ! _isCollided)
        {
           transform.position = Vector2.MoveTowards(transform.position,_followtarget.position,speed * Time.deltaTime);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out TopDownController player))
        {
            _followtarget = null;
        }
    }
}
