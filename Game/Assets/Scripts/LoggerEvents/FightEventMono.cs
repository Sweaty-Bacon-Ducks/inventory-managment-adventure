using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightEventMono : MonoBehaviour
{
	public CharacterPool cp;
    public static bool InProgress;
    public void Start()
    {

        InProgress = false;
    }

    public void Fight()
	{
        StartCoroutine(new FightEvent().EventAction(Inventories.player, cp.GetRandom(1)[0]));
        if (!InProgress)
		{
			
		}
	}
}
