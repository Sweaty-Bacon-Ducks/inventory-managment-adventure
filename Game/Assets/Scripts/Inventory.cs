using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Inventory
{
	[SerializeField]
	private List<InventoryItem> items;

	[SerializeField]
	private float maxWeight;

	[SerializeField]
	private float currentWeight;

    public WeigthSlider weigthSlider;

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

                currentWeight += item.Weight;
                OnInventoryChange();
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
        bool success = items.Remove(item);
        if (success == true)
        {
            currentWeight -= item.Weight;
            OnInventoryChange();
        }

        return success;
    }

	public bool RemoveAllFromInventory()
	{
        bool success = items.RemoveAll(x => x) > 0;

        OnInventoryChange();
        return success;
	}

    public void OnInventoryChange()
    {
        if (weigthSlider != null)
            weigthSlider.SetWeight(currentWeight);
    }
}
