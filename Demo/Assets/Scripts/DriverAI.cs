using UnityEngine;

public class DriverAI : MonoBehaviour
{
    private Rigidbody body;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        body.AddRelativeForce(new Vector3(0, 0, 10), ForceMode.Acceleration);
    }
}
