using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryUIManager : MonoBehaviour
{
    public GameObject currentSlotHover;
    public GameObject selector;

    private void Update()
    {
        CursorRaycast();
        if (currentSlotHover != null) 
        { 
            selector.SetActive(true);
            selector.transform.position = currentSlotHover.transform.position; 
        }
        if (currentSlotHover == null) 
        {
            selector.SetActive(false);
        }
    }

    private void CursorRaycast()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);

        foreach (RaycastResult raycastResult in raycastResults)
        {
            if (raycastResult.gameObject.layer == 7) { currentSlotHover = raycastResult.gameObject; }
        }

    }

}
