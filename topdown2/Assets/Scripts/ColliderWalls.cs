using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderWalls : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
        }
    }
}
