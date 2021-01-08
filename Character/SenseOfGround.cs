using UnityEngine;



public class SenseOfGround : MonoBehaviour
{
    [HideInInspector]
    public bool onGround;
    [HideInInspector]
    public string tagObject;
    [HideInInspector]
    public GameObject collisionObject;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" || collision.tag == "MovingPlatform")
            onGround = true;
        tagObject = collision.tag;
        collisionObject = collision.gameObject;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground" || collision.tag == "MovingPlatform")
            onGround = false;
        tagObject = "";
        collisionObject = null;
    }
}
