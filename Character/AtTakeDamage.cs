using System.Collections;
using UnityEngine;

public class AtTakeDamage : MonoBehaviour
{
    public bool takeDamage, // показывает, что игрок находится в коллизии с опасным объектом и должен получать урон
         takingDamage; // показывает, что игрок находится в состоянии получения урона

    private SpriteRenderer spriteRenderer;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Lava")
        {
            takeDamage = true;
            // GetComponent<CharacterJump>().SetExtrajumpsToDefault();
            GetComponent<CharacterJump>().Jump();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Lava")
        {
            takeDamage = false;
        }
    }

    private void Update()
    {
        if (takeDamage && !takingDamage)
            StartCoroutine(ToTakeDamage());
    }

    IEnumerator ToTakeDamage()
    {
        while (takeDamage)
        {
            takingDamage = true;
            GetComponent<HealthManager>().ChangeHealth(-1);

            spriteRenderer.color = new Color(1, 0, 0, 1);
            yield return new WaitForSeconds(0.15f);
            spriteRenderer.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.15f);
        }
        takingDamage = false;
    }
}
