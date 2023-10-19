using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public static Inventory Instance;

    public void AddMoney()
    {
        Debug.Log("addMoney");
    }

    public void AddHelathBottle()
    {
        Debug.Log("addHealth");
    }
}
