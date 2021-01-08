using UnityEngine;

public class StairClimbing : MonoBehaviour
{

    public bool onStair, climbing;

    [HideInInspector]
    public float vertical;

    public float speed = 3f;
    public GameObject up, down;

    private Rigidbody2D body;
    private Vector2 other;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Stair")
        {
            up.SetActive(true);
            down.SetActive(true);
            body.gravityScale = 0;
            onStair = true;
            other = collision.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Stair")
        {
            up.SetActive(false);
            down.SetActive(false);
            onStair = false;
            climbing = false;
            body.gravityScale = 1;
            vertical = 0;
        }
    }

    private void FixedUpdate()
    {
        if (onStair)
            Climbing();
    }

    private void Climbing()
    {
        climbing = true;
        up.SetActive(true);
        down.SetActive(true);
        body.gravityScale = 0;
        if (vertical == 0)
            body.velocity = new Vector2(0, 0);
        else if (vertical > 0)
            body.velocity = new Vector2(0, speed);
        else if (vertical < 0)
            body.velocity = new Vector2(0, -speed);
    }

    public void UpDownButton(float vert)
    {
        vertical = vert;
      //  GetComponent<ConditionManager>().OnStair(vertical);

    }

}
