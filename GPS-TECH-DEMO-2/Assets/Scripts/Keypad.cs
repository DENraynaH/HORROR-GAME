using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactable
{
    public bool isInteract = false;
    public GameObject keypadCamera;
    public float CameraMoveDuration;

    private void Start()
    {
        keypadCamera.SetActive(false);
    }

    public override void Interact()
    {
        if (Controller.Instance.allowInteract == false) { return; }

        if (isInteract)
        {
            Controller.Instance.ToggleInventoryInput(true);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            isInteract = false;
            Controller.Instance.UnPauseGame();
            keypadCamera.SetActive(false);
            Controller.Instance.CrosshairStatus(true);
            Controller.Instance.TooltipToggle(true);
        }
        else
        {
            Controller.Instance.ToggleInventoryInput(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            isInteract = true;
            Controller.Instance.CrosshairStatus(false);
            keypadCamera.SetActive(true);
            Controller.Instance.PauseGame();
            Controller.Instance.TooltipToggle(false);

        }

    }
}
