using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBottle : Item
{
    public override void ActionTrigger()
    {
        inventory.AddHealthBottle();
    }
}
