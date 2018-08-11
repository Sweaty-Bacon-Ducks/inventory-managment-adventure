using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHandler : MonoBehaviour {

    public Slider slider;
    public Scrollbar scrollbar;

    public void UpdateSlider()
    {
        slider.value = 1 - scrollbar.value;
    }
}
