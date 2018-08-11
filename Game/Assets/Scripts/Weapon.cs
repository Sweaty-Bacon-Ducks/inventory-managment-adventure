using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Weapon")]
public class Weapon : InventoryItem
{
	[SerializeField]
	private float maxDamage = 0.1f;
	[SerializeField]
	private float minDamage = 0.1f;

	[SerializeField]
	private float attackSpeed = 0.1f;
	
}
