using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingPlant : MonoBehaviour
{

    private Animator animator;
    private float timeBetweenAttacksOnStart;

    public Transform posToShootFrom;
    public float timeBetweenAttacks;
    public float damage;
    public GameObject projectile;
    public Enemy enemy;





    private void Start()
    {
        enemy = null;
        animator = GetComponentInChildren<Animator>();
        timeBetweenAttacksOnStart = timeBetweenAttacks;
    }

    private void Update()
    {
        if(enemy != null)
        {
            timeBetweenAttacks -= Time.deltaTime;

            if (timeBetweenAttacks <= 0)
            {
                enemy.HP -= damage;
                timeBetweenAttacks = timeBetweenAttacksOnStart;
            }
        }
        else
        {
            timeBetweenAttacks = timeBetweenAttacksOnStart;
        }
    }

    public IEnumerator ShootCaroutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(timeBetweenAttacks);
            if (animator != null)
            {
                animator.SetTrigger("attack");
            }
        }
    }

    public void Shoot()
    {
        Instantiate(projectile, posToShootFrom);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemy = collision.GetComponent<Enemy>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        enemy = null;
    }
}
