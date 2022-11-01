using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactable
{
    bool isInteract = false;
    public GameObject keypadCamera;
    public float CameraMoveDuration;

    private void Start()
    {
        keypadCamera.SetActive(false);
    }

    public override void Interact()
    {
        if (isInteract)
        {
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
