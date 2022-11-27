using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Go to cubicle action for the nurse
/// </summary>
public class GoToCubicle : GAction
{
    public override bool PrePerform()
    {
        target = inventory.FindItemWithTag("Cubicle");
        if (target == null)
            return false;
        return true;
    }

    public override bool PostPerform()
    {
        // Add one to the "TreatingPatient" world state 
        GWorld.Instance.GetWorld().ModifyState("TreatingPatient", 1);
        
        // Give back one of the cubicle
        GWorld.Instance.AddCubicle(target);
        
        // Remove the cubicle from the nurse's inventory
        inventory.RemoveItem(target);
        
        // Add one to the "FreeCubicle" world state
        GWorld.Instance.GetWorld().ModifyState("FreeCubicle", 1);
        
        return true;
    }
}
