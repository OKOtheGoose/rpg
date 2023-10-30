using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int Money;
    public int HealthBottle;
    [Header("Probability")]
    public Dictionary<int, GameObject> Probability;
    
    private void Start()
    {
        Probability = new Dictionary<int, GameObject>();
    }
    public void AddMoney(int amount = 1)
    {
        Money += amount;
    }

    public void AddHelathBottle()
    {
        HealthBottle += 1;
    }

}
