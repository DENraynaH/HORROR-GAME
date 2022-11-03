using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Document : Interactable
{
    public GameObject unclearImage;
    public GameObject clearImage;
    public bool isInteract = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (isInteract)
            {
                ToggleClearUI();
            }
        }
    }

    public override void Interact()
    {
        if (isInteract)
        {
            Controller.Instance.ToggleInventoryInput(true);
            Controller.Instance.CrosshairStatus(true);
            Controller.Instance.TooltipToggle(true);
            Controller.Instance.UnPauseGame();
            isInteract = false;
            ToggleUnclearUI();
            clearImage.SetActive(false);
        }
        else
        {
            Controller.Instance.ToggleInventoryInput(false);
            Controller.Instance.CrosshairStatus(false);
            Controller.Instance.TooltipToggle(false);
            Controller.Instance.PauseGame();
            isInteract = true;
            ToggleUnclearUI();
        }
    }

    private void ToggleUnclearUI()
    {
        if (unclearImage.activeSelf) { unclearImage.SetActive(false); }
        else { unclearImage.SetActive(true); }
    }

    private void ToggleClearUI()
    {
        if (clearImage.activeSelf) { clearImage.SetActive(false); }
        else { clearImage.SetActive(true); }
    }

}
