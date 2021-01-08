using UnityEngine;
using UnityEngine.UI;
using System;

public class Clocks : MonoBehaviour
{
    private float startTime;
    private void Start()
    {
        startTime = Time.time;
    }
    private void Update()
    {

        string nowTime = "";
        int roundTime = Convert.ToInt32(Mathf.Round(Time.time - startTime));
        int minutes = roundTime / 60;
        int seconds = roundTime % 60;
        nowTime += minutes < 10 ? "0" + minutes.ToString() + ":" : minutes.ToString() + ":";
        nowTime += seconds < 10 ? "0" + seconds.ToString() : seconds.ToString();


        gameObject.GetComponent<Text>().text = nowTime;
    }
}
