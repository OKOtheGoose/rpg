using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public static Inventory inventory = Inventory.Instance;

    private void OnTriggerEnter(Collider other)
    {
        ActionTrigger();
        Destroy(gameObject);
    }

    abstract public void ActionTrigger();
    
}
