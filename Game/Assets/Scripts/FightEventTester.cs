using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightEventTester : MonoBehaviour
{
 	public Character st;
	public Character nd;

	FightEvent fightEvent = new FightEvent();

	private void Start()
	{
		st.Reset();
		nd.Reset();
		StartCoroutine(fightEvent.EventAction(st, nd));
	}
}
