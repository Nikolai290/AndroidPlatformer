using UnityEngine;
using UnityEngine.UI;

public class WinLose : MonoBehaviour
{
    private bool isWin = false,
        isLose = false;
    public GameObject pausePanel;
    public Text pauseText, Clocks;

    public void Winner(bool win)
    {
        if (!isLose)
        {
            isWin = win;
            pausePanel.SetActive(true);
            pauseText.text = "Уровень пройден!\n Твоё время: " + Clocks.text;
            Clocks.enabled = false;
        }
    }

    public void Lose(bool lose)
    {
        isLose = lose;
        pausePanel.SetActive(true);
        pauseText.text = "Ты проиграл!\n Твоё время: " + Clocks.text;
        Clocks.enabled = false;
    }
}
