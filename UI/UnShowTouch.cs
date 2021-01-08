using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UnShowTouch : MonoBehaviour
{
    private Text text;
    private void Start()
    {
        text = GetComponent<Text>();
    }
    private void OnMouseDown()
    {
        StartCoroutine(Unshowing());

    }

    IEnumerator Unshowing()
    {
        while (text.color.a > 0)
        {
            text.color += new Color(0, 0, 0, -0.01f);
            yield return new WaitForSeconds(0.01f);
        }
        gameObject.SetActive(false);
    }
}
