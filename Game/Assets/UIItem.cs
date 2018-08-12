using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour {
    public InventoryItem item;

    private Image image;
    private new TextMeshProUGUI name;
    private TextMeshProUGUI description;
    private TextMeshProUGUI text1;
    private TextMeshProUGUI text2;
    private TextMeshProUGUI text3;

    private TextMeshProUGUI weight;
    private TextMeshProUGUI equipped;

    public bool isEquipped = false;

    private void Start()
    {
        image = transform.Find("Image").GetComponent<Image>();
        name = transform.Find("Name").GetComponent<TextMeshProUGUI>();
        description = transform.Find("Description").GetComponent<TextMeshProUGUI>();
        text1 = transform.Find("Text1").GetComponent<TextMeshProUGUI>();
        text2 = transform.Find("Text2").GetComponent<TextMeshProUGUI>();
        text3 = transform.Find("Text3").GetComponent<TextMeshProUGUI>();
        weight = transform.Find("Weight").GetComponent<TextMeshProUGUI>();
        equipped = transform.Find("Equipped").GetComponent<TextMeshProUGUI>();

        image.sprite = item.Icon;
        name.text = item.name;
        description.text = item.Description;
        text1.text = item.UIText1;
        text2.text = item.UIText2;
        text3.text = item.UIText3;
        weight.text = item.Weight.ToString("R");
    }

    public void Equip()
    {
        equipped.text = "E";
        isEquipped = true;
    }

    public void UnEquip()
    {
        equipped.text = "";
        isEquipped = false;
    }
}
