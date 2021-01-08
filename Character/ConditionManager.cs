using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ConditionManager : MonoBehaviour
{
    private Animator animator;
    public GameObject SenseOfGround;
    public Text playerState;
    private bool isGrounded,
        horizontalMove,
        verticalMove,
        move,
        hurt,
        fall,
        jump,
        onStair;
    private float prePositionY;



    private void Start()
    {
        prePositionY = transform.position.y;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        onStair = GetComponent<StairClimbing>().onStair;
        if (onStair)
            OnStair(GetComponent<StairClimbing>().vertical);



        isGrounded = SenseOfGround.GetComponent<SenseOfGround>().onGround;
        animator.SetBool("OnGround", isGrounded);
        if (fall && isGrounded)
            PlayerPrefs.SetString("Condition", "Landing");

        

        if (prePositionY > transform.position.y && !isGrounded && !onStair)
        {
            fall = true;
            jump = false;
            if (PlayerPrefs.GetString("Condition") != "Jump" && PlayerPrefs.GetString("Condition") != "ExtraJump" && !hurt)
                PlayerPrefs.SetString("Condition", "Fall");
        }
        else
            fall = false;

        if (prePositionY < transform.position.y && !isGrounded && !onStair)
            jump = true;




        switch (PlayerPrefs.GetString("Condition"))
        {

            case "Run":
                animator.SetInteger("KnightState", 1);
                break;

            case "State":
                animator.SetInteger("KnightState", 0);
                break;

            case "TakeDamage":
                // animator.SetInteger("KnightState", 6);
                break;
            case "StateOnStair":
                animator.SetInteger("KnightState", 7);
                break;
            case "ClimbingOnStair":
                animator.SetInteger("KnightState", 8);
                break;
            case "Fall":
                animator.SetInteger("KnightState", 2);
                break;

            case "Landing":
                animator.SetInteger("KnightState", 3);
                break;

            case "Jump":
                animator.SetInteger("KnightState", 4);
                break;

            case "ExtraJump":
                animator.SetInteger("KnightState", 5);
                break;

        }

        playerState.text = PlayerPrefs.GetString("Condition");

        prePositionY = transform.position.y;
    }

    public void Moving(bool isMove = false)
    {
        move = isMove;
        if (isGrounded && !jump)
            if (isMove)
            {
                PlayerPrefs.SetString("Condition", "Run");
            }
            else if (!isMove)
            {
                PlayerPrefs.SetString("Condition", "State");
            }
    }


    public void OnStair(float vertical)
    {
        Debug.Log(vertical.ToString());
        PlayerPrefs.SetString("Condition", "ClimbingOnStair");
        if (vertical == 0)
            PlayerPrefs.SetString("Condition", "StateOnStair");
    }

    public void Jump()
    {

        // простой прыжок
        if (jump || fall || !isGrounded)
        {
            // Усиленный прыжок
            PlayerPrefs.SetString("Condition", "ExtraJump");
        }
        else PlayerPrefs.SetString("Condition", "Jump");

        jump = true;
    }

}
