using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollbarHandler : MonoBehaviour {

    public Scrollbar scrollbar;
    public Slider slider;
    

    public void UpdateScrollbar()
    {
        scrollbar.value = 1 - slider.value;
    }
}
