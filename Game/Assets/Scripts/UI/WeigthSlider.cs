using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeigthSlider : MonoBehaviour {

    Slider slider;
    public Image sliderFill;

    float minWeight = 0;
    float maxWeight;

    float weigth;

    // Use this for initialization
    void Start () {
        slider = GetComponent<Slider>();
        weigth = minWeight;

        maxWeight = slider.maxValue;
        ChangeColor();
    }

    public void AddWeigth(float newWeigth)
    {
        weigth += newWeigth;
        if (weigth > maxWeight)
        {
            Debug.LogWarning("Weigth extends maxWeigth! In: " + GetType().Name);
        }

        UpdateValue();
        ChangeColor();
    }

    public void RemoveWeigth(float newWeigth)
    {
        weigth -= newWeigth;
        if (weigth < 0)
        {
            Debug.LogWarning("Weigth < 0 In: " + GetType().Name);
        }

        UpdateValue();
        ChangeColor();
    }
	
    void UpdateValue()
    {
        slider.value = weigth;
    }

    void ChangeColor()
    {
        float weightPercent = (weigth / maxWeight) * 100f;

        if (weightPercent >= 80 && weightPercent <= 100)
        {
            sliderFill.color = Color.red;
        }

        if (weightPercent >= 25 && weightPercent < 80)
        {
            sliderFill.color = Color.yellow;
        }

        if (weightPercent < 25)
        {
            sliderFill.color = Color.grey;
        }
    }
}


/*
private void Update()
{
    if (Input.GetKeyDown(KeyCode.A))
    {
        AddWeigth(3);
    }
    if (Input.GetKeyDown(KeyCode.Z))
    {
        RemoveWeigth(3);
    }
}
*/
