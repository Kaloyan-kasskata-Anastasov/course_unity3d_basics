using UnityEngine;

public class EnemiesManager : MonoBehaviour 
{
    private float _nextEnemySpawnMin = 0.4f; 
    private float _nextEnemySpawnMax = 2f;
    private float _nextEnemySpawn = 0f;

	private float _nextEnemyXCoordinateMin = 10.01f;
	private float _nextEnemyXCoordinateMax = 16.67f;
	private Vector3 _nextEnemyCoordinates = new Vector3(12f, 0.415f, 197f);
    private GameObject[] _pool;

	// Use this for initialization
	void Start () 
    {
        PopulatePool();
	}

    // Update is called once per frame
    void Update()
    {
        if (_nextEnemySpawn > 0f)
        {
            _nextEnemySpawn -= Time.deltaTime;
        }
        else
        {
            SpawnNextEnemy();
        }
	}

    void PopulatePool()
    {
        int count = transform.childCount;
        _pool = new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            _pool[i] = transform.GetChild(i).gameObject;
        }
    }

    GameObject GetNextFreeItemFromPool()
    {
        int count = _pool.Length;
        for (int i = 0; i < count; i++)
        {
            if (!_pool[i].activeSelf)
            {
                GameObject item = _pool[i];
                item.SetActive(true);
                item.transform.localScale = Vector3.one;
                return item;
            }
        }

		//Debug.Log("No free items in the pool");
        return null;
    }

    void SpawnNextEnemy()
    {
        GameObject nextEnemyGO = GetNextFreeItemFromPool();

        if (nextEnemyGO == null)
        {
            return;
        }

        _nextEnemySpawn = Random.Range(_nextEnemySpawnMin, _nextEnemySpawnMax);
        nextEnemyGO.SetActive(true);
        _nextEnemyCoordinates = new Vector3(Random.Range(_nextEnemyXCoordinateMin, _nextEnemyXCoordinateMax), 
            _nextEnemyCoordinates.y, 
            _nextEnemyCoordinates.z);
        nextEnemyGO.transform.position = _nextEnemyCoordinates;
    }
}
