using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shotPoint;
    [SerializeField] private float bulletSpeed = 15;
    private Vector2 _moveDirection;

    private void OnMove(InputAction.CallbackContext context)
    {
       _moveDirection = context.ReadValue<Vector2>();
    }

    private void OnShoot(InputAction.CallbackContext context) 
    {
        if (context.performed) 
        {
            Shoot();
        }
        Debug.Log("Shoot");
    }

    private void Move(Vector2 direction)
    {
        float scaledMoveSpeed = _moveSpeed * Time.deltaTime; 
        Vector3 moveDirection = new Vector3(direction.x, direction.y, 0);
        transform.position += moveDirection * scaledMoveSpeed;
    }

    private void Shoot() 
    { 
        var bullet = Instantiate(bulletPrefab, shotPoint.position, shotPoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = shotPoint.right * bulletSpeed;
    }

    private void FixedUpdate()
    {
        Move(_moveDirection);

        if (health <= 0) 
        {
            SceneManager.LoadScene(0);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
