using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Inventory
{
	[SerializeField]
	private List<InventoryItem> items;

	[SerializeField]
	private float maxWeight;

	[SerializeField]
	private float currentWeight;

	public Inventory(float maxWeight)
	{
		this.maxWeight = maxWeight; 
		items = new List<InventoryItem>();

	}

	public bool? AddToInventory(InventoryItem item)
	{
		if (item != null)
		{
			if (currentWeight + item.Weight <= maxWeight)
			{
				items.Add(item);
				return true;
			}
			else
			{
				return false;
			}
		}
		return null;
	}

	public bool RemoveFromInventory(InventoryItem item)
	{
		return items.Remove(item);
	}

	public bool RemoveAllFromInventory()
	{
		return items.RemoveAll(x => x) > 0;
	}
}
