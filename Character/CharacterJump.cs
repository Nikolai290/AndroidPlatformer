using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    public GameObject senseOfGround;
    public float ForceOfJump = 5f;
    public int defaultExtraJumps = 1;

    private int extraJumps;

    private void Update()
    {
        if (senseOfGround.GetComponent<SenseOfGround>().onGround)
        {
            extraJumps = defaultExtraJumps;
        }
    }
    public void CheckJump()
    {
        GetComponent<Rigidbody2D>().gravityScale = 1;

        if (senseOfGround.GetComponent<SenseOfGround>().onGround)
            Jump();
        else if (extraJumps-- > 0)
        {
            Jump();
        }
    }
    public void Jump()
    {

        GetComponent<ConditionManager>().Jump(); // Вызов изменения состояния и анимации прыжка. Если вызывается во время нахождения в прыжке, то будет состояние "Экстра прыжок", иначе обычный
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1) * ForceOfJump, ForceMode2D.Impulse);
    }
    public void AddExtraJumps(int jumps = 0)
    {
        if (jumps == 0)
            jumps = defaultExtraJumps;
        extraJumps += jumps;
    }

    public void SetExtrajumpsToDefault()
    {
        extraJumps = defaultExtraJumps;
    }

    public void SetDefaultExtraJumps(int defaultExtra)
    {
        defaultExtraJumps = defaultExtra;
    }

}
