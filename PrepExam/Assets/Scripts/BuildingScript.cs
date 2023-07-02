using UnityEngine;

public class BuildingScript : MonoBehaviour
{
	public MapGenerator MapGenerator;
	public GameObject ExplosionPrefab;
	private float _deactivateZCoordinate = -3f;

    // Update is called once per frame
    void Update()
    {
	    if (MapGenerator == null)
	    {
			return;
	    }

        transform.Translate(0f, 0f, -Time.deltaTime * MapGenerator.MapSpeed);

        if (transform.position.z <= _deactivateZCoordinate)
		{
			gameObject.SetActive(false);
		}
    }

    private void OnTriggerEnter(Collider coll)
    {
	    if (coll.tag == "Player" || coll.tag == "Rocket")
	    {
		    Explode();
		    MapGenerator.OnUpdateScore.Invoke(1);
	    }
    }

    private void Explode()
    {
	    var explosion = Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
	    explosion.SetActive(true);
	    var player = GameObject.FindGameObjectWithTag("Player");
	    var stress = Vector3.Distance(player.transform.position, transform.position) / 20;
	    stress = 1 - Mathf.Clamp01(stress);
		Camera.main.GetComponent<StressReceiver>().InduceStress(stress);

		gameObject.SetActive(false);
    }
}
