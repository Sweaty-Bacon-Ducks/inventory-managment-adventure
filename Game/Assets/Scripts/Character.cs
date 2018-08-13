using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Characters/Character")]
public class Character : ScriptableObject, IComparable
{
	[SerializeField]
	private string _name;

	private float hitPoints;

	[SerializeField]
	private float maxHitPoints;

	public bool isDead;

	[SerializeField]
	private Weapon characterWeapon;
	[SerializeField]
	private Armor characterArmor;

	[SerializeField]
	private Inventory Backpack;

	#region Properties
	public Weapon CharacterWeapon
	{
		get
		{
			return characterWeapon;
		}
	}
	public Armor CharacterArmor
	{
		get
		{
			return characterArmor;
		}
	}
	public string Name
	{
		get
		{
			return _name;
		}
	}
	public float HitPoints
	{
		get
		{
			return hitPoints;
		}
	}
	public float MaxHitPoints
	{
		get
		{
			return maxHitPoints;
		}
	}

	public bool IsDead
	{
		get
		{
			return isDead;
		}
	}
	#endregion

	public void ChangeWeapon(Weapon newWeapon)
	{
		characterWeapon = newWeapon;
		OnEquipmentChange();
	}

	public void ChangeArmor(Armor newArmor)
	{
		characterArmor = newArmor;
		OnEquipmentChange();
	}

	public void OnEquipmentChange()
	{

	}

	public void Reset()
	{
		isDead = false;
		hitPoints = maxHitPoints;
	}

	private void Die()
	{
		isDead = true;
		hitPoints = 0;
	}

	public float DealDamage(float damageAmount)
	{
		if (characterArmor)
		{
			float dealtDamage = damageAmount * (1 - (characterArmor.CurrentArmor / characterArmor.MaxArmor));
			characterArmor.Decay(damageAmount);

			hitPoints -= dealtDamage;
			if (hitPoints <= 0)
			{
				Die();
			}
			return dealtDamage;
		}
		else
		{
			float dealtDamage = damageAmount;
			hitPoints -= dealtDamage;
			if (hitPoints <= 0)
			{
				Die();
			}
			return dealtDamage;
		}
	}

	public bool PatchUp()
	{
		HealingPotion potion = Backpack.FindAndRemoveOfType<HealingPotion>();
		if (potion != null)
		{
			hitPoints += potion.HealingValue;
			if (hitPoints > MaxHitPoints)
			{
				hitPoints = MaxHitPoints;
			}
			return true;
		}
		return false;
	}

	public bool RemoveFromInventory(InventoryItem item)
	{
		return Backpack.RemoveFromInventory(item);
	}

	public bool? AddToInventory(InventoryItem item)
	{
		return Backpack.AddToInventory(item);
	}

	int IComparable.CompareTo(object obj)
	{
		Character @char = obj as Character;
		if (characterWeapon && @char.characterWeapon)
		{
			if (this.characterWeapon.AttackSpeed < @char.characterWeapon.AttackSpeed)
			{
				return -1;
			}
			else if (this.characterWeapon.AttackSpeed > @char.characterWeapon.AttackSpeed)
			{
				return 1;
			}
			else return 0;
		}
		else if(characterWeapon)
		{
			return 1;
		}
		else
		{
			return -1;
		}
	}

}
