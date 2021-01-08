using UnityEngine;

public class TriggerCollision : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {

        switch (collision.tag)
        {
            case "Finish":
                GetComponent<WinLose>().Winner(true);
                break;
            case "Heart":
                GetComponent<HealthManager>().ChangeHealth(+1);
                Destroy(collision.gameObject);
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }




}
