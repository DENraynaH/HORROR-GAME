using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotIdentifier : MonoBehaviour
{
    public int slot;
    public GameObject slotSprite;

    private void Start()
    {
        slotSprite = gameObject.transform.GetChild(0).gameObject;
    }
}
