using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Characters/Character")]
public class Character : ScriptableObject
{
	[SerializeField]
	private string _name;

	private float hitPoints;

	[SerializeField]
	private float maxHitPoints;

	private bool isDead;

	[SerializeField]
	private Weapon characterWeapon;
	[SerializeField]
	private Armor characterArmor;

	[SerializeField]
	private Inventory Backpack;

	private string Die()
	{
		return "Character {0} died!"; 
	}
	
	public void DealDamage(float damageAmount)
	{
		if (damageAmount > 0)
		{
			hitPoints -= damageAmount;
			if (hitPoints <= 0)
			{
				Die();
			}
		}
		else
		{
			Debug.LogWarning("Argument has negative value!");
		}
	}

	public void PatchUp(float healAmount)
	{
		if (healAmount > 0)
		{
			hitPoints += healAmount;
			if (hitPoints > maxHitPoints)
			{
				hitPoints = maxHitPoints;
			}
		}
		else
		{
			Debug.LogWarning("Argument has negative value!");
		}
	}

	public bool? AddToInventory(InventoryItem item)
	{
		return Backpack.AddToInventory(item);
	}
}
