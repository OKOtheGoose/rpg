using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PerkObject : MonoBehaviour
{
    public PerkType PerkType;
    private bool Collect = false;
    private bool isInTrigger;
    void OnTriggerEnter2D(Collider2D other)
    {
        isInTrigger = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isInTrigger = false;
        Collect = false;
        Debug.Log("d");
    }
    private void Update()
    {
        
        if (Collect)
        {
            Debug.Log("W");
            if (Input.GetKey(KeyCode.Alpha1))
            {
                Perks.instance.ArrPerks[0] = PerkType;
                Destroy(gameObject);
                Debug.Log("c");
            }
            if (Input.GetKey(KeyCode.Alpha2))
            {
                Perks.instance.ArrPerks[1] = PerkType;
                Destroy(gameObject);
            }
            if (Input.GetKey(KeyCode.Alpha3))
            {
                Perks.instance.ArrPerks[2] = PerkType;
                Destroy(gameObject);
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && isInTrigger)
        {
            Collect = true;
            Debug.Log("e");
        }
    }
}
