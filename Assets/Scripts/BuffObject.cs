using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffObject : MonoBehaviour
{
    public BuffType BuffsType;
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
    }
    void Update()
    {

        if (Collect)
        {
            Destroy(gameObject);
        }
        if (Input.GetKeyDown(KeyCode.E) && isInTrigger)
        {
            Collect = true;
            Buffs.instance.AddBuff(BuffsType);
        }
    }
}