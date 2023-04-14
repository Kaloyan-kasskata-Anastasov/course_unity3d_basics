using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [Header("Screens")]
    [Tooltip("MainMenu screen used for start of the game.")]
    public GameObject mainMenuScreen;
    public GameObject gameScreen;
    
    [Header("Game Over")]
    public GameObject gameOverScreen;
    public Text gameOverText;
    
    [Header("UI Elements")]
    public Image healthBar;
    public Score score;
    public Text highScore;
    
    public void ShowMainScreen()
    {
        mainMenuScreen.SetActive(true);
        gameScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        UpdateScore(0);
    }

    public void UpdateFuel(float health)
    {
        healthBar.fillAmount = health;
    }
    
    public void ShowGameScreen()
    {
        mainMenuScreen.SetActive(false);
        gameScreen.SetActive(true);
    }

    public void UpdateScore(uint value)
    {
        score.UpdateScore(value);
        score.AnimateScore(value);
    }

    public void UpdateHighScore(uint value)
    {
        highScore.text = $"High Score {value}";
    }

    public void ShowGameOver()
    {
        gameOverScreen.SetActive(true);
        gameScreen.SetActive(false);
        mainMenuScreen.SetActive(false);
        gameOverText.text = "YOU DIED";
        gameOverText.color = new Color(154, 0, 0, 255);

    }
}
