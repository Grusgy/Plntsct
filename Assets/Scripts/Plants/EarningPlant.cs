using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarningPlant : MonoBehaviour
{
    private Coins coins;


    public float timeBetweenEarns;
    public int earnAmount;
    public ParticleSystem particle;

    private void Start()
    {
        coins = FindObjectOfType<Coins>();
    }
    public IEnumerator EarningCoroutine()
    {
        while (true)
        {
            coins.coins += earnAmount;
            coins.SetCoinsText();
            yield return new WaitForSeconds(timeBetweenEarns);
            particle.Play();
        }
    }
}
