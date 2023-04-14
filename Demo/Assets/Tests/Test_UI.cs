using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class Test_UI
{
    private GameManager gameManager;

    [UnitySetUp]
    public IEnumerator UnitySetUp()
    {
        SceneManager.LoadScene("Scenes/MainScene");
        yield return null;
        gameManager = Camera.main.GetComponent<GameManager>();
    }

    [UnityTest]
    public IEnumerator StartGame_ExpectActiveGameScreen()
    {
        gameManager.OnStartGame();

        Assert.AreEqual(false, gameManager.ui.mainMenuScreen.activeSelf, "UI.mainMenuScreen is active.");
        Assert.AreEqual(true, gameManager.ui.gameScreen.activeSelf, "UI.gameScreen is inactive.");
        Assert.AreEqual(false, gameManager.ui.gameOverScreen.activeSelf, "UI.gameOverScreen is active.");
        yield return null;
    }

    [UnityTest]
    public IEnumerator ShowMainScreen_ExpectActiveMainMenuScreen()
    {
        gameManager.ui.ShowMainScreen();

        Assert.AreEqual(true, gameManager.ui.mainMenuScreen.activeSelf, "UI.mainMenuScreen is inactive.");
        Assert.AreEqual(false, gameManager.ui.gameScreen.activeSelf, "UI.gameScreen is active.");
        Assert.AreEqual(false, gameManager.ui.gameOverScreen.activeSelf, "UI.gameOverScreen is active.");
        yield return null;
    }

    [UnityTest]
    public IEnumerator ShowGameOverScreen_ExpectActiveGameOverScreen()
    {
        gameManager.ui.ShowGameOver();

        Assert.AreEqual(false, gameManager.ui.mainMenuScreen.activeSelf, "UI.mainMenuScreen is active.");
        Assert.AreEqual(false, gameManager.ui.gameScreen.activeSelf, "UI.gameScreen is active.");
        Assert.AreEqual(true, gameManager.ui.gameOverScreen.activeSelf, "UI.gameOverScreen is inactive.");
        yield return null;
    }
}
