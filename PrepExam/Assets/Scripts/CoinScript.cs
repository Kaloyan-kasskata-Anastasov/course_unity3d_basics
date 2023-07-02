using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private float _resetCoordinateZ = -20.44f;
    private float _speed = -15f;
	private float _rotateSpeed = 4f;

    // Update is called once per frame
    void Update()
    {
	    if (CarScript.IsAlive)
	    {
		    transform.Translate(transform.InverseTransformDirection(Vector3.forward) * _speed * Time.deltaTime);

		    if (transform.position.z < _resetCoordinateZ)
		    {
			    gameObject.SetActive(false);
		    }

			transform.Rotate(Vector3.back, _rotateSpeed);
	    }
    }
}
