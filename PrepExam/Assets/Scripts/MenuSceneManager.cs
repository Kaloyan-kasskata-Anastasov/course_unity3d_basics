using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneManager : MonoBehaviour
{
	void Awake()
	{
		Application.targetFrameRate = 60;
	}

	public void LoadRacingScene()
	{
		SceneManager.LoadScene("RacingScene");
	}
}
