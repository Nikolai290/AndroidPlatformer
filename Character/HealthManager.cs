using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Text healthText;
    private int Health = 500;

    [HideInInspector]
    public bool alive = true;

    private void Start()
    {
        ShowOnUI();
    }

    public void ChangeHealth(int change)
    {
  //      if (change < 0)
   //         GetComponent<ConditionManager>().DamageAnimation();
        if (Health > 0)
            Health += change;
        if (Health <= 0)
            alive = false;
        ShowOnUI();
    }

    public int GetHealth()
    {
        return Health;
    }

    private void ShowOnUI()
    {
        healthText.text = Health.ToString();
    }

    private void Update()
    {
        if (!alive)
            GetComponent<WinLose>().Lose(true);
    }
}
