using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private float _resetCoordinateZ = -20.44f;
    private float _speed = -8f;
	private float _minSpeed = -6f;
	private float _maxSpeed = -12f;

	void OnEnable()
	{
		_speed = Random.Range(_minSpeed, _maxSpeed);
	}

	// Update is called once per frame
	void Update () 
    {
	    if (CarScript.IsAlive)
	    {
		    transform.Translate(0f, 0f, _speed * Time.deltaTime);

		    if (transform.position.z < _resetCoordinateZ)
		    {
			    gameObject.SetActive(false);
		    }
	    }
    }


}
