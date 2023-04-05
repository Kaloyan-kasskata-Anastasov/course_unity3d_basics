using System.Collections.Generic;
using UnityEngine;

public class ObstaclesCreator : MonoBehaviour
{
    private const string FuelBarrelString = "FuelBarrel";
    private const string CrateString = "Crate";

    public GameObject obstacle;
    public GameObject fuelBarrel;
    public Collider newRoadTrigger;

    private static List<GameObject> obstaclesPool = new List<GameObject>();
    private static List<GameObject> fuelBarrelsPool = new List<GameObject>();

    private List<GameObject> obstaclesForDeactivation = new List<GameObject>();

    private Vector3 roadDimension = new Vector3(7, 0, 190);
    private Transform roadTransformCached;

    public void Awake()
    {
        roadTransformCached = transform;
        newRoadTrigger = GetComponent<Collider>();
    }

    public void OnDestroy()
    {
        fuelBarrelsPool.Clear();
        obstaclesPool.Clear();
    }

    public void SpawnObstacles(uint obstaclesCount)
    {
        for (int i = 0; i < obstaclesCount; i++)
        {
            GameObject newObstacle = Spawn(obstaclesPool, obstacle);
            newObstacle.name = CrateString;
        }
    }

    public void SpawnFuelBarrels(uint fuelBarrelsCount, Vector2Int fuelBarrelAmountBetween)
    {
        for (int i = 0; i < fuelBarrelsCount; i++)
        {
            GameObject newBarrel = Spawn(fuelBarrelsPool, fuelBarrel);
            newBarrel.name = FuelBarrelString;
            newBarrel.GetComponent<HealthContainer>().UpdateFuelAmount((uint) Random.Range(fuelBarrelAmountBetween.x, fuelBarrelAmountBetween.y));
        }
    }

    public GameObject Spawn(List<GameObject> pool, GameObject newObject)
    {
        Vector3 roadZone = roadTransformCached.position;

        float x = Random.Range(roadZone.x - roadDimension.x, roadZone.x + roadDimension.x);
        float z = Random.Range(roadZone.z + 20, roadZone.z + roadDimension.z);
        Vector3 position = new Vector3(x, roadZone.y, z);

        GameObject go = GetAvailable(pool, newObject, position);
        return go;
    }

    private GameObject GetAvailable(List<GameObject> pool, GameObject prefab, Vector3 position)
    {
        GameObject found = pool.Find(x => !x.activeSelf);
        if (found == null)
        {
            found = Instantiate(prefab, position, Quaternion.identity);
            found.SetActive(true);
            pool.Add(found);
        }
        else
        {
            found.transform.position = position;
            found.SetActive(true);
        }

        obstaclesForDeactivation.Add(found);
        return found;
    }

    public void DeactivateObstacles()
    {
        for (int i = 0; i < obstaclesForDeactivation.Count; i++)
        {
            obstaclesForDeactivation[i].SetActive(false);
        }

        obstaclesForDeactivation.Clear();
    }
}
