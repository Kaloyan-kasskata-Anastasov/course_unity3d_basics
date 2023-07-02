using UnityEngine;

public class SelfRotateScript : MonoBehaviour
{
	private float _rotateSpeed = 6f;

    // Update is called once per frame
    void Update()
    {
		transform.Rotate(Vector3.up, _rotateSpeed);

    }
}
