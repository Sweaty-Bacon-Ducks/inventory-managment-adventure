using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MessagingSystem : MonoBehaviour
{
	private Dictionary<string, UnityEvent> eventDictionary;

	private static MessagingSystem eventManager;

	public static MessagingSystem instance
	{
		get
		{
			if (!eventManager)
			{
				eventManager = FindObjectOfType(typeof(MessagingSystem)) as MessagingSystem;

				if (!eventManager)
				{
					Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
				}
				else
				{
					eventManager.Init();
				}
			}
			return eventManager;
		}
	}
	private void OnEnable()
	{
		if (instance.eventDictionary == null)
		{
			instance.Init();
		}
		else
		{
			DontDestroyOnLoad(instance);
		}
	}
	void Init()
	{
		if (instance.eventDictionary == null)
		{
			instance.eventDictionary = new Dictionary<string, UnityEvent>();
		}
	}

	public static void StartListening(string eventName, UnityAction listener)
	{
		UnityEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
		{
			thisEvent.AddListener(listener);
		}
		else
		{
			thisEvent = new UnityEvent();
			thisEvent.AddListener(listener);
			instance.eventDictionary.Add(eventName, thisEvent);
		}
	}

	public static void StopListening(string eventName, UnityAction listener)
	{
		if (eventManager == null) return;
		UnityEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
		{
			thisEvent.RemoveListener(listener);
		}
	}

	public static void TriggerEvent(string eventName)
	{
		UnityEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
		{
			thisEvent.Invoke();
		}
	}
}
