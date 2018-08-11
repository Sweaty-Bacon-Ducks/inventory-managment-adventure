using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Armor")]
public class Armor : InventoryItem
{
	[SerializeField]
	private float maxArmor = 100;
	[SerializeField]
	private float currentArmor = 0;
}
