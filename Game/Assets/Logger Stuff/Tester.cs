using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tester : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        for (int i = 0; i < 200; i++)
        {
            Logger.Instance.ShowLog(DateTime.Now, "JOHN CENA JOHN CENA JOHN CENA JOHN CENA " + i);
            
        }
        
	}
	
	
}
