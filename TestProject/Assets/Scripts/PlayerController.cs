using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private Text healthText;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shotPoint;
    private Vector2 _moveDirection;
    public static PlayerController player;

    private void Start()
    {
        player = this;
        healthText.text = health.ToString() + " ’œ";
    }

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
        bullet.GetComponent<NormalBullet>().Shoot(shotPoint);
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
        healthText.text = health.ToString() + " ’œ";
    }
}