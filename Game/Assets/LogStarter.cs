using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogStarter : MonoBehaviour
{
	public Sprite Start;
	public Sprite End;

	public void StartEvents()
	{
		ItemDragDrop.Lock = true;
		Debug.Log("Logger started");
	}
	
}
