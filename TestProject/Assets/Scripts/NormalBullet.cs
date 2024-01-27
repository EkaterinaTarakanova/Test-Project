using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class NormalBullet : Bullet
{
    private float lifeTime = 3;
    private int damage = 2;
    private float bulletSpeed = 15f;

    private void Awake()
    {
        Destroy(gameObject, lifeTime);
    }

    public override void Shoot(Transform shotPoint)
    {
        GetComponent<Rigidbody2D>().velocity = shotPoint.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
