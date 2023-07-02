using System;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class MapGenerator : MonoBehaviour
{
    private const float BuildingYCoordinate = 0.25f;

    public float MapSpeed;
    public float NewBuildingSpawnTimeMin = 1f;
    public float NewBuildingSpawnTimeMax = 3f;
    public GameObject[] AllBuildingTypesPrefabs;
    public int PoolSize; // This is the size for each of the building types
    public UnityIntEvent OnUpdateScore;

    private readonly Vector2 _xPositionMinMax = new Vector2(-15f, 15f);
    private readonly Vector2 _zPositionMinMax = new Vector2(57f, 72f);
    private Transform _cachedTransform;
    private GameObject[,] _buildingsPool; // Multidimensional array -> [type of building, pool of instantiated copies]
    private float _newBuildingTimer;
    private float _newBuildingSpawnTime = 2f;


    // Start is called before the first frame update
    private void Start()
    {
        _cachedTransform = transform;
        InitializePool();
    }

    // Update is called once per frame
    private void Update()
    {
        _newBuildingTimer += Time.deltaTime;
        if (_newBuildingTimer > _newBuildingSpawnTime)
        {
            _newBuildingTimer = 0f;
            _newBuildingSpawnTime = Random.Range(NewBuildingSpawnTimeMin, NewBuildingSpawnTimeMax);
            GenerateNewBuilding();
        }
    }

    private void GenerateNewBuilding()
    {
        var buildingTypes = AllBuildingTypesPrefabs.Length;
        var buildingType = Random.Range(0, buildingTypes);
        var newBuilding = GetBuildingFromPool(buildingType);
        if (newBuilding == null)
        {
            return;
        }

        var xPosition = Random.Range(_xPositionMinMax.x, _xPositionMinMax.y);
        var zPosition = Random.Range(_zPositionMinMax.x, _zPositionMinMax.y);
        newBuilding.transform.position = new Vector3(xPosition, BuildingYCoordinate, zPosition);
        newBuilding.GetComponent<BuildingScript>().MapGenerator = this;
    }

    private void InitializePool()
    {
        var buildingTypes = AllBuildingTypesPrefabs.Length;
        _buildingsPool = new GameObject[buildingTypes, PoolSize];

        for (var i = 0; i < buildingTypes; i++)
        {
            // Get the current prefab
            var buildingPrefab = AllBuildingTypesPrefabs[i];

            // Fill the corresponding pool
            for (var j = 0; j < PoolSize; j++)
            {
                // Instantiate
                var newBuilding = Instantiate(buildingPrefab, _cachedTransform);

                // Save reference to it at the pool
                // i -> type of building 
                // j -> index inside the sub array (multidimensional array)
                _buildingsPool[i, j] = newBuilding;
            }
        }
    }

    private GameObject GetBuildingFromPool(int type)
    {
        for (var i = 0; i < PoolSize; i++)
        {
            var building = _buildingsPool[type, i];
            if (!building.activeSelf)
            {
                building.SetActive(true);
                return building;
            }
        }

        return null;
    }
}

[Serializable]
public class UnityIntEvent : UnityEvent<int>
{
}
