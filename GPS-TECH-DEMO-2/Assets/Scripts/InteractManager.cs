using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractManager : MonoBehaviour
{
    public Transform raycastPosition;
    public float raycastLength;

    public Image playerCrosshair;
    public GameObject playerTooltip;
    public GameObject objectNameTooltip;
    public LayerMask raycastCollide;

    private Text playerTooltipText;
    private Text objectNameTooltipText;

    private GameObject lastObjectHovered;

    private void Start()
    {
        playerTooltipText = playerTooltip.GetComponent<Text>();
        objectNameTooltipText = objectNameTooltip.GetComponent<Text>();
    }

    private void Update()
    {
        DoRaycast();
    }

    public void DoRaycast()
    {
        DebugDrawing();
        RaycastHit hitDetails;
        if (!Physics.Raycast(raycastPosition.position, raycastPosition.TransformDirection(Vector3.forward), out hitDetails, raycastLength, raycastCollide)) 
        { 
            playerCrosshair.color = Color.white;
            playerTooltip.SetActive(false);
            objectNameTooltip.SetActive(false);
            if (lastObjectHovered != null) { lastObjectHovered.GetComponent<Outline>().OutlineMode = Outline.Mode.SilhouetteOnly; lastObjectHovered = null; }
            return; 
        }
        lastObjectHovered = hitDetails.collider.gameObject;
        Interactable interactable = lastObjectHovered.GetComponent<Interactable>();

        // < On Hover
        playerCrosshair.color = Color.red;
        if (Controller.Instance.editTooltip == true) 
        {
            playerTooltipText.text = interactable.toolTip;
            objectNameTooltipText.text = interactable.displayName;
            playerTooltip.SetActive(true); objectNameTooltip.SetActive(true);
        }
        lastObjectHovered.GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineVisible;
        // > On Hover

        if (Input.GetKeyDown(KeyCode.E))
        {
            interactable.Interact();
        }
    }

    private void DebugDrawing()
    {
        Debug.DrawRay(raycastPosition.position, raycastPosition.TransformDirection(Vector3.forward) * raycastLength, Color.red);
    }

}
