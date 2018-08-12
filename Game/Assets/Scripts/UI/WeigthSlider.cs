using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeigthSlider : MonoBehaviour {

    Slider slider;
    public Image sliderFill;

    float minWeight = 0;
    float maxWeight;

    float currentWeight;

    public TextMeshProUGUI text;

    // Use this for initialization
    void Start () {
        slider = GetComponent<Slider>();
        currentWeight = minWeight;

        maxWeight = slider.maxValue;

        UpdateUI();
        ChangeColor();
    }

    public void AddWeigth(float newWeigth)
    {
        currentWeight += newWeigth;
        if (currentWeight > maxWeight)
        {
            Debug.LogWarning("Weigth extends maxWeigth! In: " + GetType().Name);
        }

        UpdateUI();
        ChangeColor();
    }

    public void RemoveWeigth(float newWeigth)
    {
        currentWeight -= newWeigth;
        if (currentWeight < 0)
        {
            Debug.LogWarning("Weigth < 0 In: " + GetType().Name);
        }

        UpdateUI();
        ChangeColor();
    }
	
    public void SetWeight(float newWeight)
    {
        currentWeight = newWeight;
        if (currentWeight < 0 || currentWeight > maxWeight)
        {
            Debug.LogWarning("Weigth wrong In: " + GetType().Name);
        }
        UpdateUI();
        ChangeColor();
    }

    void UpdateUI()
    {
        slider.value = currentWeight;

        text.text = currentWeight + "/" + maxWeight;
    }

    void ChangeColor()
    {
        float weightPercent = (currentWeight / maxWeight) * 100f;

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
