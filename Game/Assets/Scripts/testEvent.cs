using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="new object",menuName ="Events/test")]
public class testEvent : EventSO {

    [SerializeField] private string st;

    public override void ExecuteEvent()
    {
        Debug.Log(st);
    }
}
