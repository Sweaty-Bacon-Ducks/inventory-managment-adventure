using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tester : MonoBehaviour {

    public CharacterPool cp;

	// Use this for initialization
	void Start ()
    {
        List<Character> dicks = cp.GetRandom(6);


        foreach (Character item in dicks)
        {
            Debug.Log(item.name);
        }
        for (int i = 0; i < 100; i++)
        {
            Logger.Instance.ShowLog(DateTime.Now, "JOHN CENA JOHN CENA JOHN CENA JOHN CENA " + i);

        }
        
	}
	
	
}
