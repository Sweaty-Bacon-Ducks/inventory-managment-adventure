using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Inventory : MonoBehaviour 
{
	private List<InventoryItem> Items;

	public void AddToInventory(InventoryItem item)
	{
		if (item != null)
		{
			Items.Add(item);
		}
	}

	public bool RemoveFromInventory(InventoryItem item)
	{
		return Items.Remove(item);
	}

	public bool RemoveAllFromInventory()
	{
		return Items.RemoveAll(x => x) > 0;
	}
}
