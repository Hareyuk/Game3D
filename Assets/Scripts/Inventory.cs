using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InteractiveObj> all;
    public int totalItems = 1;
    public UIInventory uiInventory;

    public void Add(InteractiveObj io)
    {
        if (IsFull()) return;
        all.Add(io);
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