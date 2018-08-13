using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public delegate void REMdel();

[Serializable]
public class EventSO : ScriptableObject
{
    virtual public void ExecuteEvent(REMdel remdel){ }
    
	
}
