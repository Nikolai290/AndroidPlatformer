using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseButtons : MonoBehaviour
{
    public GameObject pausePanel;

    private Color defaultColor,
        pressedColor = new Vector4(0.7f, 1f, 0.7f, 1f);

    private void OnMouseDown()
    {
        defaultColor = GetComponent<Image>().color;
        GetComponent<Image>().color = pressedColor;
    }

    private void OnMouseUp()
    {
        GetComponent<Image>().color = defaultColor;
    }

    private void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "PauseButton":
                pausePanel.SetActive(!pausePanel.activeSelf);
                break;
            case "RestartButton":
                SceneManager.LoadScene("Level001");
                break;
            case "":
                break;
        }
    }
}
