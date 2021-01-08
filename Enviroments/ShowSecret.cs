using System.Collections;
using UnityEngine;

public class ShowSecret : MonoBehaviour
{
    public GameObject[] tiles;
    public float endTransparent = 0;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            foreach (GameObject tile in tiles)
                StartCoroutine(Unshow(tile));
        }
    }

    IEnumerator Unshow(GameObject tile)
    {

        while (tile.GetComponent<SpriteRenderer>().color.a > endTransparent)
        {
            tile.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, -0.01f);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
