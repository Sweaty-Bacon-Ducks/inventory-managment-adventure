using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Object",menuName ="Events/ChestEvent")]
public class ChestEvent : EventSO
{
    CallBack callback;
    [SerializeField] private List<InventoryItem> booty;
    [SerializeField] private float mimicChance;
    REMdel endEvent;
    void OnValidate()
    {
        mimicChance = Mathf.Lerp(0f,1f,mimicChance);
    }


    public override void ExecuteEvent(REMdel REMD)
    {
        endEvent = REMD;
        callback = new CallBack(Continue);
        Logger.Instance.ShowLog(System.DateTime.Now,"You found a chest! Would You like to open it?(y/n)");
        InputAwaiter.Instance.GetResponse(callback);
    }
    
    public void Continue(bool response)
    {
        if (response)
        {
            Logger.Instance.ShowLog(System.DateTime.Now, "You open a chest a find inside...");
            InputAwaiter.Instance.ContinueAfter(ChestOpen, 2f);
            if (Random.Range(0,100)<=(mimicChance*100))
            {
                InputAwaiter.Instance.ContinueAfter(MimicOpen, 2f);
            }
            else
            {
                InputAwaiter.Instance.ContinueAfter(ChestOpen, 2f);
            }

        }
        else
        {
            Logger.Instance.ShowLog(System.DateTime.Now, "Yeah! Who cares about some stupid chest");
        }
        endEvent();
    }

    public void ChestOpen(bool x)
    {
        if (booty.Count==0)
        {
            Logger.Instance.ShowLog(System.DateTime.Now, "Nothing! What a waste of time!");
        }
        else
        {
            Logger.Instance.ShowLog(System.DateTime.Now, "Tresure, but you don't know how to pick it up");
        }
        endEvent();
        
    }
    public void MimicOpen(bool x)
    {
        Logger.Instance.ShowLog(System.DateTime.Now, "It was a mimic! Have fun asshat");

        endEvent();
    }

    

}
