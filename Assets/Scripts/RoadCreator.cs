using UnityEngine;

public class RoadCreator : MonoBehaviour
{
    public GameObject[] roads;
    public float roadLength = 200;

    private int lastSpawnedRoadIndex;
    private int lastRoadIndex;

    public uint ObstaclesCount { get; set; }
    public uint FuelBarrelsCount { get; set; }
    public Vector2Int FuelBarrelsAmountBetween { get; set; }

    public void Start()
    {
        lastSpawnedRoadIndex = 1;
        lastRoadIndex = 0;
    }

    public void PopulateRoad(int index)
    {
        var obstacleCreator = roads[index].GetComponent<ObstaclesCreator>();
        roads[index].SetActive(true);
        obstacleCreator.newRoadTrigger.enabled = true;
        obstacleCreator.SpawnObstacles(ObstaclesCount);
        obstacleCreator.SpawnFuelBarrels(FuelBarrelsCount, FuelBarrelsAmountBetween);
    }

    public void OnActivateNextRoad()
    {
        ReturnLastInPool();
        var currentRoadIndex = (lastSpawnedRoadIndex + 1) % roads.Length;
        GameObject road = roads[currentRoadIndex];
        road.transform.position = roads[lastSpawnedRoadIndex].transform.position + new Vector3(0, 0, roadLength);
        PopulateRoad(currentRoadIndex);
        lastSpawnedRoadIndex = currentRoadIndex;
        road.GetComponent<ObstaclesCreator>();

    }

    private void ReturnLastInPool()
    {
        roads[lastRoadIndex].SetActive(false);
        roads[lastRoadIndex].GetComponent<ObstaclesCreator>().DeactivateObstacles();
        lastRoadIndex = ++lastRoadIndex % roads.Length;
    }

}
