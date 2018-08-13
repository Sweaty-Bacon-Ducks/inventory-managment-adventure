using System;
using UnityEngine;

//[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Usable Item")]
/// <summary>
/// Class for defining usable items
/// </summary>
public class UsableItem : InventoryItem
{
	/// <summary>
	/// Virtual method for using inventory items
	/// </summary>
	public virtual void Use(object obj)
	{
		throw new NotImplementedException("Musisz zaimplementować tą metodę!");
	}
}
