﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEventManager : MonoBehaviour
{
    [SerializeField] private float eventChance;
    [SerializeField] private float frequency;
    [SerializeField] private List<EventSO> eventList;

    public float Frequency { set { frequency = Mathf.Max(value, 0.01f); } get { return frequency; } }
    public float EventChance { set { eventChance = Mathf.Lerp(0f, 1f, value); } get { return eventChance; } }
    void OnValidate()
    {
        frequency = Mathf.Max(frequency, 0.01f);
        eventChance = Mathf.Lerp(0f, 1f, eventChance);
    }

    public static bool stateSwitch = false;
	
    private IEnumerator Overwatch()
    { 
        while (stateSwitch)
        {
            EventCheck();
            yield return new WaitForSeconds(frequency);
        }
    }

    private void EventCheck()
    {
        if (Random.Range(0, 100) <= (eventChance * 100)) Execute();
    }

    private void Execute()
    {
        REMOff();
        eventList[Random.Range(0, eventList.Count)].ExecuteEvent();
        REMOn();
    }

    public void REMOn()
    {
        if (!stateSwitch)
        {
            stateSwitch = true;
            StartCoroutine(Overwatch());
        }
    }

    public void REMOff()
    {
        stateSwitch=false;
    }
}
