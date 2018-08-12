using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemDragged;
    public static Transform startParent;

    private Inventories inv;

    private void Start()
    {
        inv = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Inventories>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemDragged = gameObject;
        startParent = transform.parent;
        if (startParent.parent.parent.name == "PlayerInventoryUI")
        {
            inv.playerInventory.RemoveFromInventory(ItemDragDrop.itemDragged.GetComponent<UIItem>().item);
        }
        else if (startParent.parent.parent.name == "ShopUI")
        {
            inv.shopInventory.RemoveFromInventory(ItemDragDrop.itemDragged.GetComponent<UIItem>().item);
        }
        else
        {
            Debug.LogWarning("Problem with names in ItemDragDrop script");
        }

        transform.SetParent(transform.root);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        AudioManager.instance.Play("ItemDrop");

        if (transform.parent == startParent || transform.parent == transform.root)
        {
            Debug.Log("Miejsce sie nie zmienilo");
            transform.SetParent(startParent);
        }
        
        transform.localPosition = Vector3.zero;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        itemDragged = null;
        startParent = null;
    }
}
