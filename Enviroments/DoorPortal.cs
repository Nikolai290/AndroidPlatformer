using System.Collections;
using UnityEngine;

public class DoorPortal : MonoBehaviour
{
    public Transform destination;

    [HideInInspector]
    public bool onDoor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        onDoor = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onDoor = false;
    }

}
