using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<InventoryItem> debugList = new List<InventoryItem>();
    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private InventoryUIManager inventoryUIManager;
    [SerializeField] private Transform dropPosition;

    public static int inventorySize = 9;
    public static List<InventoryItem> currentInventory = new List<InventoryItem>();
    public List<GameObject> inventoryItemSprites = new List<GameObject>();

    private void Start()
    {
        inventoryUI.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        inventoryUIManager = inventoryUI.GetComponent<InventoryUIManager>();
    }

    private void Update()
    {
        debugList = currentInventory;
        InventoryInputManager();
    }

    private void InventoryInputManager()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (inventoryUI.activeSelf) 
            {
                CloseInventory();
            }
            else 
            {
                OpenInventory();
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (GetHoveredItem() == null) { return; }
            int hoveredSlot = GetSlotHovered();
            if (currentInventory.ElementAtOrDefault(hoveredSlot) == null) { return; }

            InventoryItem hoveredItem = currentInventory[hoveredSlot];
            hoveredItem.itemObject.transform.position = dropPosition.position;
            hoveredItem.itemObject.SetActive(true);
            currentInventory.Remove(hoveredItem);
            CloseInventory();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (GetHoveredItem() == null) { return; }
            int hoveredSlot = GetSlotHovered();
            if (currentInventory.ElementAtOrDefault(hoveredSlot) == null) { return; }

            InventoryItem hoveredItem = currentInventory[hoveredSlot];
            Destroy(hoveredItem.itemObject);
            currentInventory.Remove(hoveredItem);
            CloseInventory();
        }
    } 

    public static void InventoryAdd(string itemName, int itemAmount, GameObject itemObject, Sprite itemSprite, Color color)
    {
        if (!InventoryFull()) { currentInventory.Add(new InventoryItem(itemName, itemAmount, itemObject, itemSprite, color)); }
    }

    public static bool InventoryFull()
    {
        bool isInventoryFull = false;
        if (currentInventory.Count >= inventorySize) { isInventoryFull = true; }
        return isInventoryFull;
    }

    public int GetSlotHovered()
    {
        return inventoryUIManager.currentSlotHover.GetComponent<SlotIdentifier>().slot;
    }

    public GameObject GetHoveredItem()
    {
        return inventoryUIManager.currentSlotHover;
    }

    private void CloseInventory()
    {
        inventoryUI.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;

        foreach (GameObject inventorySprite in inventoryItemSprites)
        {
            inventorySprite.GetComponent<Image>().sprite = null;
            inventorySprite.GetComponent<Image>().color = Color.white;
        }
        inventoryUIManager.currentSlotHover = null;
    }

    private void OpenInventory()
    {
        for (int i = 0; i < currentInventory.Count; i++)
        {
            inventoryItemSprites[i].GetComponent<Image>().sprite = currentInventory[i].itemSprite;
            inventoryItemSprites[i].GetComponent<Image>().color = currentInventory[i].color;
        }
        inventoryUI.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }


}

public class InventorySlot
{
    public InventorySlot(int slotMax, int slotAmount, InventoryItem slotItem)
    {
        this.slotMax = slotMax;
        this.slotAmount = slotAmount;
        this.slotItem = slotItem;
    }

    public int slotMax { get; private set; }
    public int slotAmount { get; private set; }
    public InventoryItem slotItem { get; set; }
}

[Serializable]
public class InventoryItem
{
    public InventoryItem(string itemName, int itemAmount, GameObject itemObject, Sprite itemSprite, Color color)
    {
        this.itemName = itemName;
        this.itemAmount = itemAmount;
        this.itemObject = itemObject;
        this.itemSprite = itemSprite;
        this.color = color;
    }
    public string itemName;
    public int itemAmount;
    public GameObject itemObject;
    public Sprite itemSprite;
    public Color color;

}
