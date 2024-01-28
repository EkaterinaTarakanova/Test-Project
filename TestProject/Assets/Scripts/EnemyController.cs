using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] private int health = 10;
    [SerializeField] private float enemySpeed = 10f;
    [SerializeField] private int damage = 10;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void MoveLeft() 
    {
        _rigidbody.velocity = new Vector2(-enemySpeed, _rigidbody.velocity.y);
    }

    private void FixedUpdate()
    {
        MoveLeft();

        CheckLeftBoundary();

        if (health <= 0) 
        {
            Destroy(gameObject);
            EnemyCounter.killCounter++;
        }
    }

    public void TakeDamage(int damage) 
    {
        health -= damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DamagePlayer(PlayerController.player);
        }
    }

    private void DamagePlayer(PlayerController player)
    {
        if (player != null)
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    private float GetLeftBoundary() 
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
    }

    private void CheckLeftBoundary() 
    {
        if (transform.position.x < GetLeftBoundary())
        {
            DamagePlayer(PlayerController.player);
        }
    }
}
