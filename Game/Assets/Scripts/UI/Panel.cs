using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Panel : MonoBehaviour, IDropHandler {

    public Inventories inv;

    // If player dropped the item on this panel
    public void OnDrop(PointerEventData eventData)
    {
		if (ItemDragDrop.Lock)
			return;
		if (ItemDragDrop.leftMouseButton == false)
            return;

        if (ItemDragDrop.itemDragged != null)
        {
            ItemDragDrop.itemDragged.transform.SetParent(transform.GetChild(0));

            if (transform.parent.name == "PlayerInventoryUI")
            {
                if (inv.playerInventory.AddToInventory(ItemDragDrop.itemDragged.GetComponent<UIItem>().item) == true)
                {
                    inv.shopInventory.RemoveFromInventory(ItemDragDrop.itemDragged.GetComponent<UIItem>().item);
                }
                else
                    ItemDragDrop.itemDragged.transform.SetParent(ItemDragDrop.startParent);
            }
            else if (transform.parent.name == "ShopUI")
            {
                if (inv.shopInventory.AddToInventory(ItemDragDrop.itemDragged.GetComponent<UIItem>().item) == true)
                {
                    inv.playerInventory.RemoveFromInventory(ItemDragDrop.itemDragged.GetComponent<UIItem>().item);
                }
                else
                    ItemDragDrop.itemDragged.transform.SetParent(ItemDragDrop.startParent);
            }
            else
            {
                Debug.LogWarning("Problem with names in Panel script");
            }
        }
    }
}
