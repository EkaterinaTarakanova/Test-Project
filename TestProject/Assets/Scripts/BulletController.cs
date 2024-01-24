using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletController : MonoBehaviour
{
    private float lifeTime = 3;
    private int damage = 2;

    private void Awake()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        { 
            EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
            if (enemy != null) 
            {
                enemy.TakeDamage(damage);
            }
        }
        Destroy(gameObject);
    }
}
