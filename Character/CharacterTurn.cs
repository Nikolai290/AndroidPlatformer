using UnityEngine;

public class CharacterTurn : MonoBehaviour
{

    public void Turn(float xDirection)
    {

        if (!GetComponent<StairClimbing>().onStair)
            if (xDirection > 0)
            {
                if (transform.localScale.x < 0)
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
            else if (xDirection < 0)
            {
                if (transform.localScale.x > 0)
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
    }
}
