using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Box_Script : MonoBehaviour
{
    [SerializeField] public int hp;
    [SerializeField] private LayerMask damagelayerMask;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject go = GameObject.Find("Bullet 1");
        bullet bulletscript = go.GetComponent<bullet>();

        if (LayerMaskUtil.ContainsLayer(damagelayerMask, collision.gameObject) && bulletscript._hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
