using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public float maxHealth = 30;

    public GameObject mainMenuScreen;

    public GameObject gameScreen;
    public Image healthBar;
    public Score score;

    public GameObject gameOverScreen;
    public Text gameOverText;

    private uint currentScore;
    public float currentHealth;

    private void Start()
    {
        Time.timeScale = 0;
        currentHealth = maxHealth;
        mainMenuScreen.SetActive(true);
        gameScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        UpdateScore(0);
    }

    private void Update()
    {
        currentHealth -= Time.deltaTime;
        float percentMaxHealth = Mathf.InverseLerp(0, maxHealth, currentHealth);
        healthBar.fillAmount = percentMaxHealth;
        if (percentMaxHealth == 0)
        {
            ShowGameOver();
        }
    }

    public void OnStartGameClicked()
    {
        Time.timeScale = 1;
        mainMenuScreen.SetActive(false);
        gameScreen.SetActive(true);
    }

    public void UpdateHealth(int value)
    {
        float clampedValue = currentHealth + value;
        if (clampedValue < 0)
        {
            currentHealth = 0;
        }
        else if (clampedValue > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void UpdateScore(int value)
    {
        currentScore += (uint)Mathf.Clamp(value, 0, int.MaxValue);
        score.UpdateScore(currentScore);

        this.score.AnimateScore(value);
    }

    public void ShowGameOver()
    {
        gameScreen.SetActive(false);
        gameOverScreen.SetActive(true);
        gameOverText.text = "YOU DIED";
        gameOverText.color = new Color(154, 0, 0, 255);

    }
}
