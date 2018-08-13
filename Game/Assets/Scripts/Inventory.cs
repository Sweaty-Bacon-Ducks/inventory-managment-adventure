using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Inventory
{
    public Character character;

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
	public T FindOfType<T>() where T : InventoryItem
	{
		foreach (InventoryItem item in items)
		{
			if (typeof(T) == item.GetType())
			{
				return item as T;
			}
		}
		return null;
	}

	public T FindAndRemoveOfType<T>() where T : InventoryItem
	{
		T result = this.FindOfType<T>();
		if (result != null)
		{
			this.items.Remove(result);
		}
		return result;
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


    internal void EquipWeapon(InventoryItem item)
    {
        //Debug.Log("Equipping weapon: " + item.name);
        character.ChangeWeapon((Weapon)item);
    }

    internal void EquipArmor(InventoryItem item)
    {
        //Debug.Log("Equipping armor: " + item.name);
        character.ChangeArmor((Armor)item);
    }
}
