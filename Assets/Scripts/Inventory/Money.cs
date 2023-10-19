using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : Item
{
    public override void ActionTrigger()
    {
        inventory.AddMoney();
    }
}
