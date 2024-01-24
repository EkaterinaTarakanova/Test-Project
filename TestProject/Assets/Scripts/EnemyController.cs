using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private int health = 10;

    private void FixedUpdate()
    {
        if (health <= 0) 
        { 
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage) 
    {
        health -= damage;
    }
}
