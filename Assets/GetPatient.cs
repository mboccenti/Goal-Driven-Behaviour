using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPatient : GAction
{
    GameObject resource;

    public override bool PrePerform()
    {
        target = GWorld.Instance.RemovePatient();
        if(target == null)
            return false;

        resource = GWorld.Instance.RemoveCubicle();
        if (resource != null)
        {
            inventory.AddItem(resource);
        }
        else
        {
            // No cublices available, the patient gets back in line
            GWorld.Instance.AddPatient(target);
            target = null;
            return false;
        }
        
        // One less cubicle available
        GWorld.Instance.GetWorld().ModifyState("FreeCubicle", -1);

        return true;
    }

    public override bool PostPerform()
    {
        // Patient is not waiting anymore
        GWorld.Instance.GetWorld().ModifyState("Waiting", -1);

        if (target)
        {
            target.GetComponent<GAgent>().inventory.AddItem(resource);
        }
        return true;
    }
}
