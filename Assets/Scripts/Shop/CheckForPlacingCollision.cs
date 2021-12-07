using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForPlacingCollision : MonoBehaviour
{

    public int collisionCounter;

    private void Start()
    {
        collisionCounter = 0;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisionCounter++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collisionCounter--;
    }
}
