using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Logger : MonoBehaviour
{
    private static Logger instance;
    public static Logger Instance { get { return instance; } }

    [SerializeField] private TMP_Text contentWindow;
    [SerializeField] private ScrollRect scrollRect;
    private void Awake()
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

    public void ShowLog(DateTime datetime, string log)
    {
        string txt = datetime.Minute+":"+datetime.Second + " " + log + Environment.NewLine;
        contentWindow.text += txt;
        StartCoroutine(GetDown());
    }

    IEnumerator GetDown()
    {
        yield return new WaitForEndOfFrame();
        scrollRect.verticalNormalizedPosition = 0f;
    }


   
    

}
