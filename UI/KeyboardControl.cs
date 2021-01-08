using Unity.Mathematics;
using UnityEngine;

public class KeyboardControl : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown("right"))
            GetComponent<CharacterRun>().MovementButton(1);
        else if (Input.GetKeyDown("left"))
            GetComponent<CharacterRun>().MovementButton(-1);
        else if (Input.GetKeyUp("left") || Input.GetKeyUp("right"))
            GetComponent<CharacterRun>().MovementButton(0);


        if (Input.GetKeyDown("up"))
        {
            if (GetComponent<StairClimbing>().onStair && !GetComponent<DoorTeleport>().onDoor)
                GetComponent<StairClimbing>().UpDownButton(1);
            else if (!GetComponent<StairClimbing>().onStair && GetComponent<DoorTeleport>().onDoor)
                GetComponent<DoorTeleport>().Teleport();
        }
        else if (Input.GetKeyDown("down"))
            GetComponent<StairClimbing>().UpDownButton(-1);
        else if (Input.GetKeyUp("up") || Input.GetKeyUp("down"))
            GetComponent<StairClimbing>().UpDownButton(0);


        if (Input.GetKeyDown(KeyCode.Space))
            GetComponent<CharacterJump>().CheckJump();

    }
}
