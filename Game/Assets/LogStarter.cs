using UnityEngine;

public class LogStarter : MonoBehaviour
{
	public Sprite Start;
	public Sprite End;

	public FightEventMono fem;

	public void StartEvents()
	{
		ItemDragDrop.Lock = true;

		if (FightEventMono.InProgress == false)
		{
			fem.Fight();
		}
		Debug.Log("Logger started");
	}
	
}
