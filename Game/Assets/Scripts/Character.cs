using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
	public string Name = "";

	public float HitPoints;
	public float MaxHitPoints;

	public bool IsDead;

	public Character(string Name,float MaxHitPoints = 100)
	{
		this.Name = Name;

		this.MaxHitPoints = MaxHitPoints;
		this.HitPoints = MaxHitPoints;

		this.IsDead = false;
	}

	private string Die()
	{
		return "Character {0} died!"; 
	}

	public void DealDamage(float damageAmount)
	{
		if (damageAmount > 0)
		{
			HitPoints -= damageAmount;
			if (HitPoints <= 0)
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
			HitPoints += healAmount;
			if (HitPoints > MaxHitPoints)
			{
				HitPoints = MaxHitPoints;
			}
		}
		else
		{
			Debug.LogWarning("Argument has negative value!");
		}
	}
}
