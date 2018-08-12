using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    public static GameObject itemDragged;
    public static Transform startParent;

    public static bool leftMouseButton;

    private Inventories inv;

    public static UIItem activeWeapon;
    public static UIItem activeArmor;

    private void Start()
    {
        inv = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Inventories>();

        activeWeapon = null;
        activeArmor = null;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && transform.parent.parent.parent.name == "PlayerInventoryUI")
        {
            if (gameObject.GetComponent<UIItem>().isEquipped == true)
            {
                gameObject.GetComponent<UIItem>().UnEquip();

                if (gameObject.GetComponent<UIItem>().item.GetType().ToString() == "Weapon")
                {
                    inv.playerInventory.EquipWeapon(null);
                    activeWeapon = gameObject.GetComponent<UIItem>();
                }
                if (gameObject.GetComponent<UIItem>().item.GetType().ToString() == "Armor")
                {
                    inv.playerInventory.EquipArmor(null);
                    activeArmor = gameObject.GetComponent<UIItem>();
                }


                return;
            }

            //Debug.Log(gameObject.GetComponent<UIItem>().item.GetType());
            if (gameObject.GetComponent<UIItem>().item.GetType().ToString() == "Weapon")
            {
                if (activeWeapon != null)
                    activeWeapon.UnEquip();

                inv.playerInventory.EquipWeapon(gameObject.GetComponent<UIItem>().item);
                gameObject.GetComponent<UIItem>().Equip();

                activeWeapon = gameObject.GetComponent<UIItem>();
            }
            if (gameObject.GetComponent<UIItem>().item.GetType().ToString() == "Armor")
            {
                if (activeArmor != null)
                    activeArmor.UnEquip();

                inv.playerInventory.EquipArmor(gameObject.GetComponent<UIItem>().item);
                gameObject.GetComponent<UIItem>().Equip();

                activeArmor = gameObject.GetComponent<UIItem>();
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        leftMouseButton = true;
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            leftMouseButton = false;

            return;
        }

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (gameObject.GetComponent<UIItem>().isEquipped == true)
            {
                leftMouseButton = false;
                return;
            }
        }


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
        if (leftMouseButton)
            transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!leftMouseButton)
            return;

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
