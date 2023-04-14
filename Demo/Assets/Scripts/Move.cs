using UnityEngine;

public class Move : MonoBehaviour
{
    private float driveSpeed = 20f;
    private float turnSpeed = 20f;

    public float forwardInput;
    public float sideInput;

    public void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        sideInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * Time.deltaTime * driveSpeed * forwardInput);
        if (forwardInput != 0)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * (turnSpeed * sideInput));
        }
    }
}