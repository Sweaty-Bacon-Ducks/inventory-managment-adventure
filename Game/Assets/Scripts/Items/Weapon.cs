using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Weapon")]
public class Weapon : InventoryItem
{
	[Range(0f, 1f)]
	[SerializeField]
	private float hitChance;

	public float HitChance
	{
		get
		{
			return hitChance;
		}
	}
	[Range(0f, 1f)]
	[SerializeField]
	private float criticalHitChance;

	[Range(0.1f, 100f)]
	[SerializeField]
	private float criticalMultiplier;

	public float CriticalMultiplier
	{
		get
		{
			return criticalMultiplier;
		}
	}

	public float CriticalHitChance
	{
		get
		{
			return criticalHitChance;
		}
	}

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
