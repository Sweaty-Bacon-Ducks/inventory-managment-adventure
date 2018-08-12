using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Panel : MonoBehaviour, IDropHandler {

    // If player dropped the item on this panel
    public void OnDrop(PointerEventData eventData)
    {
        if (ItemDragDrop.itemDragged != null)
            ItemDragDrop.itemDragged.transform.SetParent(transform.GetChild(0));
    }
}
