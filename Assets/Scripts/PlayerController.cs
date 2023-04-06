using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalInput;
    public float horizontalInput;
    public float rollInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rollInput = 0;
        transform.Translate(Vector3.forward * speed);
        
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");
        // get the user's vertical input
        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.Q))
        {
            rollInput = -1;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            rollInput = 1;
        }

        // tilt the plane up/down/left/right based on arrow keys
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime * verticalInput);
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * horizontalInput);
        transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime * rollInput);
    }   
}
