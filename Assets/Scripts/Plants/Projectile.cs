using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator animator;

    public int damage;
    public float projectileSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(projectileSpeed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        projectileSpeed = 0;
        animator.SetTrigger("hit");
        collision.GetComponent<Enemy>().HP -= damage;
    }

    public void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
