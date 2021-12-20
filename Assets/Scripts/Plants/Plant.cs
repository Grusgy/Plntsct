using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{

    private bool isCounted;

    public float HP;
    public BoxCollider2D boxCollider;
    public int price;



    private void Update()
    {
        if(HP <= 0)
        {
            Destroy(gameObject);
        }
    }




}
