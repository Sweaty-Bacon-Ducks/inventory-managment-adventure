using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Weapon")]
public class Weapon : InventoryItem
{
	[SerializeField]
	private float damage = 1;
	[SerializeField]
	private float attackInterval = 0.1f;

}
