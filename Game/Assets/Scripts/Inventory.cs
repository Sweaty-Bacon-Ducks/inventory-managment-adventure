using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	private List<InventoryItem> items;

	public void AddToInventory(InventoryItem item)
	{
		if (item != null)
		{
			items.Add(item);
		}
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
