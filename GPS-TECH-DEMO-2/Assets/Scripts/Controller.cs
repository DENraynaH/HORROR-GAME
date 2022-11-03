using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour 
{
    public GameObject crosshair;
    public static Controller Instance;
    public GameObject FreezeMovement;

    public GameObject tooltip;
    public GameObject nameTooltip;

    public bool editTooltip;
    public bool allowInteract;
    public bool allowInventoryInput;
    public bool onGoingVoiceline;

    private void Start()
    {
        onGoingVoiceline = false;
        allowInventoryInput = true;
        allowInteract = true;
        editTooltip = true;
        Instance = this;
    }

    public void PauseGame() { FreezeMovement.SetActive(false); }
    public void UnPauseGame() { FreezeMovement.SetActive(true); }
    public void CrosshairStatus(bool enabled)
    {
        if (enabled) { crosshair.SetActive(true); }
        else { crosshair.SetActive(false); }
    }

    public void TooltipToggle(bool status)
    {
        if (status) { tooltip.SetActive(true); nameTooltip.SetActive(true); editTooltip = true; }
        else { tooltip.SetActive(false); nameTooltip.SetActive(false); editTooltip = false; }
    }

    public void CursorToggle(bool status)
    {
        if (status) 
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void ToggleInteractInput(bool status)
    {
        if (status) { allowInteract = true; }
        else { allowInteract = false; }
    }

    public void ToggleInventoryInput(bool status)
    {
        if (status) { allowInventoryInput = true; }
        else { allowInventoryInput = false; }
    }
}