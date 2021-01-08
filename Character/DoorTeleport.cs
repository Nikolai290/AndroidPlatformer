using System.Collections;
using UnityEngine;

public class DoorTeleport : MonoBehaviour
{
    public GameObject buttonTeleport;

    private Transform destination;



    [HideInInspector]
    public bool onDoor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Door")
        {
            buttonTeleport.SetActive(true);
            onDoor = true;
            destination = collision.GetComponent<DoorPortal>().destination;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Door")
        {
            buttonTeleport.SetActive(false);
            onDoor = false;
        }
    }

    public void Teleport()
    {

        if (onDoor)
            StartCoroutine(Teleporting(destination));
    }

    IEnumerator Teleporting(Transform destination)
    {
        while (GetComponent<SpriteRenderer>().color.a > 0)
        {
            GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, -0.01f);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.5f);
        transform.position = destination.position;
        yield return new WaitForSeconds(0.5f);

        while (GetComponent<SpriteRenderer>().color.a < 1)
        {
            GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.01f);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
