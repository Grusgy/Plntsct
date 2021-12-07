using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingPlant : MonoBehaviour
{

    private Animator animator;


    public float timeBetweenAttacks;
    public GameObject projectile;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }


    public IEnumerator ShootCaroutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(timeBetweenAttacks);
            animator.SetTrigger("attack");
        }
    }
    
}
