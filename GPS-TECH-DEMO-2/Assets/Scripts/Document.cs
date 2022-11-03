using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Document : Interactable
{
    public GameObject unclearImage;
    public GameObject clearImage;

    public override void Interact()
    {
        ToggleUnclearUI();
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
