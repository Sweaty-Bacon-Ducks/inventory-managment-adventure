using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Object",menuName ="Events/ChestEvent")]
public class ChestEvent : EventSO
{
    CallBack callback;
    [SerializeField] private string x;


    public override void ExecuteEvent()
    {
        callback = new CallBack(Continue);
        InputAwaiter.Instance.GetRespose(callback);
    }


    
   
    public void Continue(bool response)
    {
        Logger.Instance.ShowLog(System.DateTime.Now, x);
    }

    

}
