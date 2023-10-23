using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public Inventory inventory;

    private void OnTriggerEnter2D(Collider2D other)
    {
        ActionTrigger();
        Destroy(gameObject);
    }

    abstract public void ActionTrigger();
    
}
