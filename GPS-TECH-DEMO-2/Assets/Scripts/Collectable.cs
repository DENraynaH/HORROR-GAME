using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Interactable
{
    public Sprite itemSprite;
    public Color color;
    public string itemDescription;

    public override void Interact()
    {
        if (InventoryManager.InventoryFull()) { return; }
        InventoryManager.InventoryAdd(interactableName, 1, gameObject, itemSprite, color, itemDescription);
        this.gameObject.SetActive(false);
    }
}
