using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Armor")]
public class Armor : InventoryItem
{
	[SerializeField]
	private float maxArmor = 100;

	public float MaxArmor
	{
		get
		{
			return maxArmor;
		}
	}

    [SerializeField]
    private float currentArmor = 0;

	public float CurrentArmor
	{
		get
		{
			return currentArmor;
		}
	}
	public void Decay(float damage)
	{
		currentArmor -= damage;
		if (currentArmor < 0)
		{
			currentArmor = 0;
		}
	}
	public void Reset()
	{
		currentArmor = maxArmor;
	}
}
