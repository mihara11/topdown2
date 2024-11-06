using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Box_Script : MonoBehaviour
{
    public int health = 5; 
    public GameObject splinterPrefab; 
    public int splinterCount = 5; 
    public float splinterForce = 5f; 

    
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("-1");
        if (health <= 0)
        {
            DestroyBox();
        }
    }

   
    private void DestroyBox()
    {
        for (int i = 0; i < splinterCount; i++)
        {
          
            GameObject splinter = Instantiate(splinterPrefab, transform.position, Random.rotation);
            
            Rigidbody rb = splinter.GetComponent<Rigidbody>();
            if (rb != null)
            {
                
                Vector3 randomDirection = Random.insideUnitSphere.normalized;
                rb.AddForce(randomDirection * splinterForce, ForceMode.Impulse);
            }
        }

      
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(1);
            Destroy(collision.gameObject); 
            Debug.Log("-1");
        }
    }
}
