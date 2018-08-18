using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    public Inventories inv;
    public GameObject grid;

    private void Start()
    {
        for (int i = 0; i < grid.transform.childCount; ++i)
        {
            inv.shopInventory.AddToInventory(grid.transform.GetChild(i).GetComponent<UIItem>().item);
        }
    }
}
