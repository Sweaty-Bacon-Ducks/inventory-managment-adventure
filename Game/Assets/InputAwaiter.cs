using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public delegate void CallBack(bool response);
public delegate void CallbackParams(params object[] items);

public class InputAwaiter : MonoBehaviour
{
    private bool ocupied = false;
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
    
    public void GetResponse(CallBack callBack)
    {
        query.Add(callBack);

        if (ocupied==false)
        {
            ocupied = true;
            StartCoroutine(WaitForResponse());
        }
    }

    public void ContinueAfter(CallBack callBack, float t)
    {
        StartCoroutine(WaitForSeconds(callBack, t));
    }

    private void CleanUp()
    {
        ocupied = false;
        query.RemoveAt(0);

        if (query.Count > 0)
        {
            ocupied = true;
            StartCoroutine(WaitForResponse());
        }
    }


    private bool answer;
    private IEnumerator WaitForResponse()
    {
        bool answered = false;
        while (!answered)
        {          
            if (Input.GetKey("y"))
            {
                answer = true;
            }
            if (Input.GetKey("n"))
            {
                answer = false;
            }
            if (Input.GetKeyUp("y") || Input.GetKeyUp("n"))
            {
                answered = true;
            }
            yield return null;
        }
        
        query[0](answer);
        CleanUp();
        
    }
    

    private IEnumerator WaitForSeconds(CallBack callBack, float t)
    {
        yield return new WaitForSeconds(t);
        callBack(true);

    }
    
}
