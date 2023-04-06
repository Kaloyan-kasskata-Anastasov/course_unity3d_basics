using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField]
    private Image gameOverScreen;
    public Text gameOverText;
    public Image timerImage;
    public GateCounterUI GateCounterUi;

    public void Start()
    {
        gameOverScreen.gameObject.SetActive(false);
        timerImage.fillAmount = 1;
    }

    public void UpdateTimer(float value, int max)
    {
        timerImage.fillAmount = Mathf.InverseLerp(0, max, value);
    }

    public void UpdateGateCounter(int value, int maxGates)
    {
        GateCounterUi.UpdateUI(value, maxGates);
    }

    public void ShowGameOverScreenPassed()
    {
        gameOverScreen.gameObject.SetActive(true);
        gameOverText.text = GameManager.State.ToString().ToUpper();
        gameOverText.color = Color.green;
    }

    public void ShowGameOverScreenDeath()
    {
        gameOverScreen.gameObject.SetActive(true);
        gameOverText.text = GameManager.State.ToString().ToUpper();
        gameOverText.color = Color.red;
    }

    public void ShowGameOverScreenFail()
    {
        gameOverScreen.gameObject.SetActive(true);
        gameOverText.text = GameManager.State.ToString().ToUpper();
        gameOverText.color = Color.red;
    }

    public void OnRestartClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }
}
