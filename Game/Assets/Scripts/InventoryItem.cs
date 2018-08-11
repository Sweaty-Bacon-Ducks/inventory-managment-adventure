using UnityEngine;
using System;

/// <summary>
/// Interface for inventory items
/// </summary>
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class InventoryItem : ScriptableObject
{
	public string Name = "";
	public string Description = "";
	public bool Usable = true;

	public Sprite Icon = null;
	/// <summary>
	/// Virtual method for using inventory items
	/// </summary>
	public virtual void Use()
	{
		throw new NotImplementedException("Musisz zaimplementować tą metodę!");
	}
}