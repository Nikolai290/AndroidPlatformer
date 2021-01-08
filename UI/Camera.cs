using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject hero,
        //  floor,
        wallLeft,
        wallRigth;
      //  ceiling;


    private void Update()
    {
        float targetX = hero.transform.position.x;
        float targetY = transform.position.y;

        if (targetX < wallLeft.transform.position.x + 9.5f)
            targetX = wallLeft.transform.position.x + 9.5f;
        else if (targetX > wallRigth.transform.position.x - 8.5f)
            targetX = wallRigth.transform.position.x - 8.5f;
        /*
        if (targetY < floor.transform.position.y + 4.55f)
            targetY = floor.transform.position.y + 4.5f;
        else if (targetY > ceiling.transform.position.y - 5f)
            targetY = ceiling.transform.position.y - 5f;
*/



            Vector3 target = new Vector3(targetX, targetY, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime*2);
    }
}
