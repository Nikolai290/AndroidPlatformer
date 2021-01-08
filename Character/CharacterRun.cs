using UnityEngine;

public class CharacterRun : MonoBehaviour
{
    public GameObject senseOfGrond;
    public float speedOfRun = 5f;
    [HideInInspector]
    public float xDirecrion;

    private void Update()
    {
        GetComponent<ConditionManager>().Moving(senseOfGrond.GetComponent<SenseOfGround>().onGround && xDirecrion != 0);
    }
    private void FixedUpdate()
    {
        Run(xDirecrion);
    }
    public void Run(float xDirection=0)
    {
        GetComponent<CharacterTurn>().Turn(xDirection);
       /* if (senseOfGrond.GetComponent<SenseOfGround>().onGround && xDirection !=0)
            GetComponent<ConditionManager>().Moving(true);
        else
            GetComponent<ConditionManager>().Moving(false);*/
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + speedOfRun * xDirection, transform.position.y), Time.deltaTime * speedOfRun);
    }



    public void MovementButton(float xDir)
    {
        xDirecrion = xDir;
    }

}
