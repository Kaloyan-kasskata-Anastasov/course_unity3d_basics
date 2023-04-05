using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Paused,
        Playing,
        GameOver
    }

    private enum ScoreBoard
    {
        Crate = 10,
        Barrel = 20,
        Barrier = 30
    }

    public const string CrateString = "Crate";
    private const string ScoreString = "Score";
    public static GameState PlayState { get; set; }

    public UI ui;
    public RoadCreator roadCreator;
    public CarController car;
    public Pesho pesho;

    [Range(1f, 10f)]
    public int minFuelAmount;

    [Range(10f, 20f)]
    public int maxFuelAmount;


    private uint currentScore;
    public float currentHealth;

    public float maxHealth = 30;

    public void Start()
    {
        roadCreator.ObstaclesCount = 30;
        roadCreator.FuelBarrelsCount = 5;
        roadCreator.FuelBarrelsAmountBetween = new Vector2Int(10, 20);
        roadCreator.PopulateRoad(0);
        roadCreator.PopulateRoad(1);
        roadCreator.roads[0].GetComponent<ObstaclesCreator>().newRoadTrigger.enabled = false;

        pesho.onLookForTarget = () => car.transform;
        Time.timeScale = 0;
        currentHealth = maxHealth;
        currentScore = 0;
        ui.ShowMainScreen();
    }

    private void Update()
    {
        currentHealth -= Time.deltaTime;
        float percentMaxHealth = Mathf.InverseLerp(0, maxHealth, currentHealth);
        ui.UpdateFuel(percentMaxHealth);
        if (percentMaxHealth == 0)
        {
            ui.ShowGameOver();
        }
    }

    public void OnStartGame()
    {
        Time.timeScale = 1;
        ui.ShowGameScreen();
    }

    public void OnNewRoadTrigger()
    {
        roadCreator.OnActivateNextRoad();
    }

    public void OnObstacleHit(string obstacleName)
    {
        if (obstacleName.Contains(CrateString))
        {
            currentScore += (uint) ScoreBoard.Crate;
            ui.UpdateScore(currentScore);
        }
    }

    public void OnGameOver()
    {
        PlayState = GameState.GameOver;
        ui.ShowGameOver();
        uint highScore = (uint) PlayerPrefs.GetInt(ScoreString);
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt(ScoreString, (int) currentScore);
        }

        ui.UpdateHighScore(highScore);
    }

    public void OnFuelHit(HealthContainer barrel)
    {
        float clampedValue = currentHealth + barrel.FuelAmount;
        if (clampedValue < 0)
        {
            currentHealth = 0;
        }
        else if (clampedValue > maxHealth)
        {
            currentHealth = maxHealth;
        }

        ui.UpdateFuel(barrel.FuelAmount);
        barrel.gameObject.SetActive(false);
    }

    public void OnDriverGetToCar()
    {
        PlayState = GameState.Playing;
    }
}
