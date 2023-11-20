using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public ItemAmount itemAmount;
    public int Money;
    public int HealthBottle;
    public void AddMoney(int amount = 1)
    {
        Money += amount;
        itemAmount.UpdateMoneyAmount(Money);
    }
    public void AddHealthBottle(int amount = 1)
    {
        HealthBottle += amount;
        itemAmount.UpdateHealthBottleAmount(HealthBottle);
    }
}
