using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public enum DoorState { Open, Closed }
    public DoorState doorState;

    public float doorSpeed;

    public Vector3 target;
    public Vector3 doorClosedPosition;
    public Vector3 doorOpenPosition;

    private void Start()
    {
        target = doorClosedPosition;
    }

    public void ToggleDoor()
    {
        if (doorState == DoorState.Closed)
        {
            target = doorClosedPosition;
            doorState = DoorState.Open;
        }
        else
        {
            target = doorOpenPosition;
            doorState = DoorState.Closed;
        }
   }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) { ToggleDoor(); }
        transform.position = Vector3.Lerp(transform.position, target, doorSpeed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(doorOpenPosition, 3);
        Gizmos.DrawWireSphere(doorClosedPosition, 3);
    }

}
