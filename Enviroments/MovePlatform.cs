using System.Collections;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public GameObject[] wayPoints; // массив точек, по которым будет двигаться платформа
    public float moveSpeed = 1f; // скорость движения платформы
    public bool isWaiting = true; // галочка в инспекторе, нужно ли ставить задержку в конечных точках
    public float wait = 0.5f; // время задержки платформы в точках

    private int i = 0; // указывает позицию в массиве
    private bool stopping; // состояние остановки платформы на каждой из точек

    private void Update()
    {
        if (transform.position != wayPoints[i].transform.position && !stopping)
            movePlatform(wayPoints[i], moveSpeed);
        else if (isWaiting && !stopping)
        {
            if (transform.position == wayPoints[i].transform.position)
                StartCoroutine(Waiting());
        }
        else if (i < wayPoints.Length - 1)
            i++;
        else
            i = 0;
    }

    public void StartMove()
    {
        for (int i = 0; i < wayPoints.Length; i++)
        {
            if (transform.position != wayPoints[i].transform.position)
            {
                movePlatform(wayPoints[i], moveSpeed);
            }
        }
    }


    public void movePlatform(GameObject point, float movespeed)
    {
        transform.position = Vector2.MoveTowards(transform.position, point.transform.position, movespeed * Time.deltaTime);
    }

    IEnumerator Waiting()
    {
        stopping = true;
        yield return new WaitForSeconds(wait);
        stopping = false;
    }
}
