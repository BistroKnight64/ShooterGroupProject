using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class playerchase : MonoBehaviour
{
    public static event Action<playerchase> OnEnemyKilled;
    [SerializeField] float health, maxHealth = 3f;
    [SerializeField] float moveSpeed = 5f;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        health = maxHealth;
        target = GameObject.Find("Player").transform;
    }
    public void TakeDamage(float damageAmount)
    {

    }
   
    private void FixedUpdate()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            moveDirection = direction;
        }
        if (target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }
}