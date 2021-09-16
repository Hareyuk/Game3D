using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InteractiveObj> all;
    public int totalItems = 5;
    public UIInventory uiInventory;

    public void Refresh()
    {
        uiInventory.RefreshInventory();
        uiInventory.HighlightSelectedItem();
    }

    public void Add(InteractiveObj io)
    {
        if (IsFull()) return;
        all.Add(io);
        uiInventory.positionInventory = all.Count -1;
        uiInventory.RefreshInventory();
    }
    public void Remove(InteractiveObj io)
    {
        all.Remove(io);
        uiInventory.RefreshInventory();
    }
    public bool IsFull()
    {
        if (all.Count >= totalItems)
            return true;
        return false;
    }
    public Pickup GetPickupObject()
    {
        foreach (InteractiveObj io in all)
        {
            if (io.GetComponent<Pickup>())
                return io.GetComponent<Pickup>();
        }
        return null;
    }
}
