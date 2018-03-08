using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory {
    private List<BaseItem> items = new List<BaseItem>();
	
    public void AddItem(BaseItem item)
    {
        items.Add(item);
        Debug.Log("added " + item);
    }
}
