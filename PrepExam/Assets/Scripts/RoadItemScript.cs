using UnityEngine;

public class RoadItemScript : MonoBehaviour
{
	public GameObject ExplosionPrefab;
	private RoadScript _roadScript;
	private float _deactivateZCoordinate = -4f;
	private float _randomSpeedMultiplierMin = 40f;
	private float _randomSpeedMultiplierMax = 44f;
	private float _randomSpeedMultiplier = 1f;


	void OnEnable()
	{
		if (_roadScript == null)
		{
			_roadScript = FindObjectOfType<RoadScript>();
		}

		_randomSpeedMultiplier = Random.Range(_randomSpeedMultiplierMin, _randomSpeedMultiplierMax);
	}

	// Update is called once per frame
	void Update()
	{
		if (_roadScript == null)
		{
			return;
		}

		transform.position += Vector3.back * Time.deltaTime * _roadScript.RoadSpeed * _randomSpeedMultiplier;
		//transform.Translate(0f, 0f, -Time.deltaTime * _roadScript.RoadSpeed * _randomSpeedMultiplier);

		if (transform.position.z <= _deactivateZCoordinate)
		{
			gameObject.SetActive(false);
		}
	}

	private void OnTriggerEnter(Collider coll)
	{
		if (transform.tag == "Health")
		{
			gameObject.SetActive(false);
			return;
		}

		if (coll.tag == "Player")
		{
			Explode();
		}
	}

	private void Explode()
	{
		var explosion = Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
		explosion.SetActive(true);
		Destroy(explosion, 2f);
		gameObject.SetActive(false);
	}
}
