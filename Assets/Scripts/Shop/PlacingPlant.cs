using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingPlant : MonoBehaviour
{

    private GameObject currentPlaceableObject;
    private Vector3 worldPosition;
    private Coins coins;
    public bool isPlacingObject;
    public int objectIndex;
    


    private void Start()
    {
        objectIndex = -1;
        coins = FindObjectOfType<Coins>();
    }

    private void Update()
    {
        if (currentPlaceableObject != null)
        {
            worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            MoveCurrentObjectToMouse();
            ReleaseIfClicked();

        }

    }

    public void HandleNewObject(GameObject plant)
    {

        if (currentPlaceableObject != null)
        {
            Destroy(currentPlaceableObject);
        }
        else
        {
            currentPlaceableObject = Instantiate(plant);

        }

    }


    private void MoveCurrentObjectToMouse()
    {
        currentPlaceableObject.transform.position = new Vector3(worldPosition.x, worldPosition.y, 0);
            
        
    }



    private void ReleaseIfClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int plantPrice = currentPlaceableObject.GetComponent<Plant>().price;
            if (plantPrice <= coins.coins)
            {
                if (worldPosition.y < 6 && worldPosition.y > 0 && worldPosition.x > 2 && worldPosition.x < 11)
                {
                    if (currentPlaceableObject.GetComponentInChildren<CheckForPlacingCollision>().collisionCounter <= 0)
                    {
                        float xPos = currentPlaceableObject.transform.position.x;
                        float yPos = currentPlaceableObject.transform.position.y;
                        Vector2 clampPos = new Vector2(Mathf.Sign(xPos) * (Mathf.Abs((int)xPos) + 0.5f),
                            Mathf.Sign(yPos) * (Mathf.Abs((int)yPos) + 0.5f));
                        currentPlaceableObject.transform.position = clampPos;
                        coins.coins -= plantPrice;
                        coins.SetCoinsText();
                        var earningPlant = currentPlaceableObject.GetComponent<EarningPlant>();
                        var shootingPlant = currentPlaceableObject.GetComponent<AttackingPlant>();
                        if (earningPlant != null)
                        {
                            StartCoroutine(earningPlant.EarningCoroutine());
                        }
                        else if (shootingPlant != null)
                        {
                            StartCoroutine(shootingPlant.ShootCaroutine());
                        }
                        currentPlaceableObject = null;
                    }
                }
            }
            else
            {
                Destroy(currentPlaceableObject.gameObject);
                print("you dont have enough money");
            }
            
        }
        if(Input.GetMouseButtonDown(1))
        {
            Destroy(currentPlaceableObject.gameObject);
            print("destroied");

        }
    }



}
