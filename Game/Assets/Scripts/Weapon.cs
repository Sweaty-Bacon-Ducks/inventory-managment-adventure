using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Weapon")]
public class Weapon : InventoryItem
{
	[SerializeField]
	private float maxDamage = 0.1f;

	public float MaxDamage
	{
		get
		{
			return maxDamage;
		}
	}

	[SerializeField]
	private float minDamage = 0.1f;

	public float MinDamage
	{
		get
		{
			return minDamage;
		}
	}

	[SerializeField]
	private float attackSpeed = 0.1f;

	public float AttackSpeed
	{
		get
		{
			return attackSpeed;
		}
	}
}
