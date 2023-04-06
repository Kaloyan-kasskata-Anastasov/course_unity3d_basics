using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const string SceneName = "MainScene";

    public enum GameState
    {
        Playing,
        Dead,
        Fail,
        Passed
    }

    [Header("References")]
    public static GameState State;

    public UI ui;
    public PlayerController player;

    public GatesController GatesController;

    [Header("Gate Settings")]
    public float distance = 1.0f;

    public float positionTolerance = 0.5f;
    public float angleTolerance = 0.5f;

    [Header("Game Rules")]
    public int maxGatesCount = 10;
    public int gateTimeBonusValue = 5;
    public int countdownMaxValue = 5;

    private Gate gateCached;
    private int gatesPassed;
    private float currentCountdownValue;

    public void Start()
    {
        gateCached = GatesController.SpawnNext(GetNextGatePosition(player.transform), GetNextGateDirection(player.transform.rotation));
        gateCached = GatesController.SpawnNext(GetNextGatePosition(gateCached.Transform), GetNextGateDirection(gateCached.Transform.rotation));
        State = GameState.Playing;
        currentCountdownValue = countdownMaxValue;
        ui.UpdateGateCounter(gatesPassed, maxGatesCount);
        ui.UpdateTimer(currentCountdownValue, countdownMaxValue);
    }

    public void Update()
    {
        currentCountdownValue -= Time.deltaTime;
        ui.UpdateTimer(currentCountdownValue, countdownMaxValue);
        if (currentCountdownValue <= 0)
        {
            State = GameState.Fail;
            ui.ShowGameOverScreenFail();
        }
    }

    public void PlaneGateTrigger(GameObject gate)
    {
        currentCountdownValue += gateTimeBonusValue;
        ui.UpdateTimer(currentCountdownValue, countdownMaxValue);
        ui.UpdateGateCounter(++gatesPassed, maxGatesCount);
        if (gatesPassed >= maxGatesCount)
        {
            State = GameState.Passed;
            ui.ShowGameOverScreenPassed();
        }

        gateCached = GatesController.SpawnNext(GetNextGatePosition(gateCached.Transform), GetNextGateDirection(gateCached.Transform.rotation));
        GatesController.Disable(gate.GetComponent<Gate>());
    }

    public void PlaneHitSomething()
    {
        State = GameState.Dead;
        ui.ShowGameOverScreenDeath();
    }

    private Vector3 GetNextGatePosition(Transform relativeTransform)
    {
        Vector3 offset = relativeTransform.position + relativeTransform.forward * distance;
        Vector3 position = new Vector3(
            Random.Range(-positionTolerance, positionTolerance),
            Random.Range(-positionTolerance, positionTolerance),
            Random.Range(-positionTolerance, positionTolerance)
        );

        return offset + position;
    }

    private Quaternion GetNextGateDirection(Quaternion relativeRotation)
    {
        Quaternion randomRotation = Quaternion.Euler(
            Random.Range(-angleTolerance, angleTolerance),
            Random.Range(-angleTolerance, angleTolerance),
            Random.Range(-angleTolerance, angleTolerance));
        return relativeRotation * randomRotation;
    }

    public void OnRestartClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneName);
    }
}
