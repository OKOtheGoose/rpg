using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int Money;
    public int HealthBottle;
    public void AddMoney(int amount = 1)
    {
        Money += amount;
    }

    public void AddHelathBottle()
    {
        HealthBottle += 1;
    }
}
