using UnityEngine;

public class CarSoundController : MonoBehaviour
{
    private AudioSource audioSource;

    public float minPitch;
    private CarController car;

    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        car = GetComponent<CarController>();
    }

    public void Start()
    {
        audioSource.pitch = minPitch;
        audioSource.Play();
    }

    public void LateUpdate()
    {
        float forwardSpeed = car.Rigidbody.velocity.magnitude * 4f / car.driveSpeed;
        audioSource.pitch = forwardSpeed < minPitch ? 
            minPitch : 
            forwardSpeed;
    }
}
