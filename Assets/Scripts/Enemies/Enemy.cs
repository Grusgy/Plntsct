using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float damage;
    public float speed;
    public float HP;
    public float timeBetweenAttacks;
    public Plant plantEnemyIsHitting;
    public int moneyForKill;

    private float timeBetweenAttacksOnStart;
    private Rigidbody2D rb;


    private void Start()
    {
        plantEnemyIsHitting = null;
        timeBetweenAttacksOnStart = timeBetweenAttacks;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        plantEnemyIsHitting = collision.GetComponent<Plant>();
 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        plantEnemyIsHitting = null;
    }

    private void Update()
    {
        rb.velocity = new Vector2(-speed, 0);
        if(plantEnemyIsHitting != null)
        {
            timeBetweenAttacks -= Time.deltaTime;
            if(timeBetweenAttacks <= 0)
            {
                plantEnemyIsHitting.HP -= damage;
                timeBetweenAttacks = timeBetweenAttacksOnStart;
            }
        }
        else
        {
            timeBetweenAttacks = timeBetweenAttacksOnStart;
        }
        if(HP<= 0)
        {
            FindObjectOfType<Coins>().coins += moneyForKill;
            Destroy(gameObject);
        }
    }
}
