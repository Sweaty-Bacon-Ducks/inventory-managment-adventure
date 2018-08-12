using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Logger : MonoBehaviour
{
    private static Logger instance;
    [SerializeField] private ScrollRect scrollRect;

    public static Logger Instance { get { return instance; } }

    [SerializeField] private TMP_Text contentWindow;

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

        //scrollRect = GetComponentInChildren<ScrollRect>();
    }

    public void ShowLog(DateTime datetime, string log)
    {
        string txt = datetime.Minute+":"+datetime.Second + " " + log + Environment.NewLine;
        contentWindow.text += txt;
        GetDown();

    }


    public void GetDown()
    {
        //scrollRect.verticalScrollbar.value = 0f;
        scrollRect.velocity = new Vector2(0, 10000);
    }




}
