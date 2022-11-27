using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTreated: GAction
{
    GameObject resource;

    public override bool PrePerform()
    {
        target = inventory.FindItemWithTag("Cubicle");
        if(target == null)
            return false;

        return true;
    }

    public override bool PostPerform()
    {
        // Patient is getting treated
        GWorld.Instance.GetWorld().ModifyState("Treated", 1);
        
        inventory.RemoveItem(target);

        return true;
    }
}
