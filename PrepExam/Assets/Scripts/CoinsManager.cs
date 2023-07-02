using UnityEngine;

public class CoinsManager : MonoBehaviour 
{
    private float _nextCoinSpawnMin = 0.4f;
    private float _nextCoinSpawnMax = 2f;
    private float _nextCoinSpawn = 0f;
	 
	private float _nextCoinXCoordinateMin = 10.62f;
	private float _nextCoinXCoordinateMax = 17.55f;
	private Vector3 _nextCoinCoordinates = new Vector3(0f, 0.339f, 197f);
    private GameObject[] _pool;

    // Use this for initialization
    void Start()
    {
        PopulatePool();
    }

    // Update is called once per frame
    void Update()
    {
        if (_nextCoinSpawn > 0f)
        {
            _nextCoinSpawn -= Time.deltaTime;
        }
        else
        {
            SpawnNextCoin();
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
                item.transform.localScale = new Vector3(0.5f, 0.02f, 0.5f);
                return item;
            }
        }

        Debug.Log("No free items in the pool");
        return null;
    }

    void SpawnNextCoin()
    {
        GameObject nextCoinGO = GetNextFreeItemFromPool();

        if (nextCoinGO == null)
        {
            return;
        }

        _nextCoinCoordinates.x = Random.Range(_nextCoinXCoordinateMin, _nextCoinXCoordinateMax);
        _nextCoinSpawn = Random.Range(_nextCoinSpawnMin, _nextCoinSpawnMax);
        nextCoinGO.SetActive(true);
        nextCoinGO.transform.position = _nextCoinCoordinates;
    }
}
