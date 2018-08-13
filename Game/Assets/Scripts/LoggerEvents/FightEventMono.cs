using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightEventMono : MonoBehaviour
{
	public CharacterPool cp;
	public static bool InProgress = false;
	public void Fight()
	{
		if (!InProgress)
		{
			StartCoroutine(new FightEvent().EventAction(Inventories.player, cp.GetRandom(1)[0]));

		}
	}
}
