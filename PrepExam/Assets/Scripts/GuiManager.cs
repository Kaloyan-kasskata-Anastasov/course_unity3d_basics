using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GuiManager : MonoBehaviour 
{
    public GameObject PlayerDeadLbl;
    public Text ScoreLbl;

    public void OnHomeClicked()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void OnResetLevelClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ShowDeadText()
    {
        PlayerDeadLbl.SetActive(true);
    }

    public void OnClearScoreClicked()
    {
        PlayerPrefs.DeleteAll();
        GameObject.FindObjectOfType<CarScript>().Score = 0;
        ScoreLbl.text = string.Format("Score : {0}", 0);
    }
}
