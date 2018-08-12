using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventories : MonoBehaviour {

    public Inventory playerInventory;
    public Inventory shopInventory;

    public WeigthSlider playerSlider;
    public Character player;

    public void Awake()
    {
        playerInventory = new Inventory(50f);
        shopInventory = new Inventory(9999f);
    }

    public void Start()
    {
        playerInventory.weigthSlider = playerSlider;
        player = new Character();
        playerInventory.character = player;
    }

    //public LayerMask layers;
    //public Camera cam;

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

    //        if (hit.collider != null)
    //        {
    //            Debug.Log("Hit: " + hit.collider.transform.name);
    //        }
    //        else
    //        {
    //            Debug.Log("WTF");
    //        }
    //        //RaycastHit hit;
    //        //Ray ray = cam.ScreenPointToRay(Input.mousePosition);

    //        //if (Physics.Raycast(ray, out hit, layers))
    //        //{
    //        //    Transform objectHit = hit.transform;
    //        //    Debug.Log("Trafiono na: " + objectHit.name);
    //        //    // Do something with the object that was hit by the raycast.
    //        //}
    //    }
    //}
}
