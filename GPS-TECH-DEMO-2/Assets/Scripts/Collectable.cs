using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Interactable
{
    public Sprite itemSprite;
    public Color color;

    public override void Interact()
    {
        if (InventoryManager.InventoryFull()) { return; }
        InventoryManager.InventoryAdd(interactableName, 1, gameObject, itemSprite, color);
        this.gameObject.SetActive(false);
    }
}
