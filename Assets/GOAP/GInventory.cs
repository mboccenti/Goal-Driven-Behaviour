using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GInventory
{
    List<GameObject> items = new List<GameObject>();

    public void AddItem(GameObject item) { items.Add(item); }
    
    public void RemoveItem(GameObject i) 
    {
        int indexToRemove = -1;
        foreach (GameObject item in items)
        {
            indexToRemove++;
            if (item == i)
                break;
            if(indexToRemove>=-1)
                items.RemoveAt(indexToRemove);
        }
    }

    public GameObject FindItemWithTag(string tag)
    {
        foreach (GameObject item in items)
        {
            if (item.tag == tag) { return item; }
        }
        return null;
    }
}
