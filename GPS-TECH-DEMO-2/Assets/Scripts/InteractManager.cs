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
            return; 
        }
        GameObject objectHit = hitDetails.collider.gameObject;
        Interactable interactable = objectHit.GetComponent<Interactable>();

        // < On Hover
        playerCrosshair.color = Color.red;
        playerTooltip.SetActive(true); objectNameTooltip.SetActive(true);
        playerTooltipText.text = interactable.toolTip;
        objectNameTooltipText.text = interactable.displayName;
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
