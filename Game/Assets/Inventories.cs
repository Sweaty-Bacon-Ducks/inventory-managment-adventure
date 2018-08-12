using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventories : MonoBehaviour {

    public Inventory playerInventory;
    public Inventory shopInventory;

    public WeigthSlider playerSlider;

    public void Awake()
    {
        playerInventory = new Inventory(50f);
        shopInventory = new Inventory(9999f);
    }

    public void Start()
    {
        playerInventory.weigthSlider = playerSlider;
    }
}
