using UnityEngine;

public class RoadScript : MonoBehaviour
{
    public Material RoadMaterial;
    public float RoadSpeed;
    public Transform PoolParent;

    public float NewRoadItemSpawnTimeMin = 1f;
    public float NewRoadItemSpawnTimeMax = 3f;
    public GameObject[] AllRoadTypesPrefabs;
    public int PoolSize; // This is the size for each of the building types

    private float _currentOffset;

    private readonly Vector2 _xPositionMinMax = new Vector2(-3f, 3f);
    private readonly Vector2 _zPositionMinMax = new Vector2(31f, 53f);
    private GameObject[,] _roadItemsPool; // Multidimensional array -> [type of car, pool of instantiated copies]
    private float _newRoadItemTimer;
    private float _newRoadSpawnTime = 2f;

    // Start is called before the first frame update
    private void Start()
    {
        InitializePool();
    }

    // Update is called once per frame
    private void Update()
    {
        _newRoadItemTimer += Time.deltaTime;
        if (_newRoadItemTimer > _newRoadSpawnTime)
        {
            _newRoadItemTimer = 0f;
            _newRoadSpawnTime = Random.Range(NewRoadItemSpawnTimeMin, NewRoadItemSpawnTimeMax);
            AddNewRoadItem();
        }

        _currentOffset += RoadSpeed * Time.deltaTime;
        RoadMaterial.SetTextureOffset("_MainTex", Vector2.down * _currentOffset);
    }

    private void AddNewRoadItem()
    {
        var allRoadItemTypes = AllRoadTypesPrefabs.Length;
        var roadItemType = Random.Range(0, allRoadItemTypes);

        //var newRoadItem = Instantiate(AllRoadTypesPrefabs[roadItemType]);
        var newRoadItem = GetRoadItemFromPool(roadItemType);
        if (newRoadItem == null)
        {
            return;
        }

        newRoadItem.gameObject.SetActive(true);

        var xPosition = Random.Range(_xPositionMinMax.x, _xPositionMinMax.y);
        var zPosition = Random.Range(_zPositionMinMax.x, _zPositionMinMax.y);

        newRoadItem.transform.position = new Vector3(xPosition, 0f, zPosition);
    }

    private void InitializePool()
    {
        var allRoadItemTypes = AllRoadTypesPrefabs.Length;
        _roadItemsPool = new GameObject[allRoadItemTypes, PoolSize];

        for (var i = 0; i < allRoadItemTypes; i++)
        {
            // Get the current prefab
            var prefab = AllRoadTypesPrefabs[i];

            // Fill the corresponding pool
            for (var j = 0; j < PoolSize; j++)
            {
                // Instantiate
                var newItem = Instantiate(prefab, PoolParent);
                newItem.SetActive(false);

                // Save reference to it at the pool
                // i -> type of car 
                // j -> index inside the sub array (multidimensional array)
                _roadItemsPool[i, j] = newItem;
            }
        }
    }

    private GameObject GetRoadItemFromPool(int type)
    {
        for (int i = 0; i < _roadItemsPool.GetLength(1); i++)
        {
            GameObject go = _roadItemsPool[type, i];
            if (!go.activeSelf)
            {
                return go;
            }
        }

        return null;
    }
}
