using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coins : MonoBehaviour
{
    public int coins;
    public TMP_Text coinText;

    private void Awake()
    {
        SetCoinsText();
    }

    public void SetCoinsText()
    {
        coinText.text = coins.ToString();
    }

    private void Update()
    {
        coinText.text = coins.ToString();
    }
}
