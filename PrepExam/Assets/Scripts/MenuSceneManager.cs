using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneManager : MonoBehaviour
{
	public void OnLoadGameScene()
	{
		SceneManager.LoadScene("MainScene");
	}

	public void OnExitGame()
	{
		Application.Quit();
		Debug.Log("Exit Game");
	}
}
