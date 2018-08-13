using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public delegate void CallBack(bool response);

public class InputAwaiter : MonoBehaviour
{
    private bool ocupied;
    private List<CallBack> query = new List<CallBack>();
    private static InputAwaiter instance;
    public static InputAwaiter Instance { get { return instance; } }


    void Awake()
    {
        if (instance!=null&&instance!=this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    
    public void GetRespose(CallBack callBack)
    {
        
        if (!ocupied)
        {
            ocupied = true;
            StartCoroutine(WaitForResponse(callBack));
        }
        else
        {
            query.Add(callBack);
        }
        
    }

    private IEnumerator WaitForResponse(CallBack callBack)
    {
        //while (!y || !n)
        //{
        //    if (Input.GetKey("y")) response = true;
        //    if (Input.GetKey("n")) response = false;
        //    yield return null;
        //}
        for (int i = 0; i < 5; i++)
        {
            Logger.Instance.ShowLog(DateTime.Now, (i+1).ToString());
            yield return new WaitForSeconds(1);
        }
        callBack(true);
        ocupied = false;
        GetRespose(query[1]);
        query.RemoveAt(1);

        

    }
}
