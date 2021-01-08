using System.Collections;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public bool fexedFrameTime;
    public Sprite[] sprites;
    public float frameTime = 0.1f, rndTimeMin = 0.1f, rndTimeMax = 0.2f;
    public int startFrame = 0;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(ScriptAnimation());
    }

    IEnumerator ScriptAnimation()
    {
        int i = 0;
        if (startFrame < sprites.Length - 1)
            i = startFrame;
        while (true)
        {
            if (fexedFrameTime)
                yield return new WaitForSeconds(frameTime);
            else
                yield return new WaitForSeconds(Random.RandomRange(rndTimeMin, rndTimeMax));
            spriteRenderer.sprite = sprites[i];
            i++;
            if (i > sprites.Length - 1)
                i = 0;
        }
    }
}
