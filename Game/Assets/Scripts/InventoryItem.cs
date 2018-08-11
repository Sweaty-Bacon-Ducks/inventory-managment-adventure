using UnityEngine;
using System;


//[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
/// <summary>
/// Interface for inventory items
/// </summary>
[Serializable]
public class InventoryItem : ScriptableObject
{
	public string Name = "";
	public string Description = "";
	public float Weight = 0;
	public float Price = 0;

	public Sprite Icon;
}
