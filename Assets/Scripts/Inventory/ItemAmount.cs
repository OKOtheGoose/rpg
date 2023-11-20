using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemAmount : MonoBehaviour
{
    public TextMeshProUGUI Money;
    public TextMeshProUGUI HealthBottle;
    public void UpdateMoneyAmount(int amount)
    {
        Money.text = amount.ToString();
    }
    public void UpdateHealthBottleAmount(int amount)
    {
        HealthBottle.text = amount.ToString();
    }
}
