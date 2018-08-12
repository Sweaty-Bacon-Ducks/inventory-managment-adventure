using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item",menuName ="Inventory/Healing Potion")]
public class HealingPotion : UsableItem
{
    [SerializeField] private float healingValue;

    public override void Use(object obj)
    {

    }
	
}
