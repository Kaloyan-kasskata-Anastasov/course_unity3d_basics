using UnityEngine;

public class CarController : MonoBehaviour
{
    private float forwardInput;
    private float sideInput;

    public int driveSpeed;
    public int turnSpeed;

    public ParticleSystem leftSteamSmoke;
    public ParticleSystem rightSteamSmoke;
    public ParticleSystem leftSmoke;
    public ParticleSystem rightSmoke;

    public Color DisableOverheatColor = Color.gray;
    public Color EnabledOverheatSteamColor = Color.yellow;
    public Color EnabledOverheatColor = Color.red;

    private Rigidbody car;
    public bool IsDriverInTheCar;

    public void Start()
    {
        car = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        if (IsDriverInTheCar == false)
        {
            return;
        }

        forwardInput = Input.GetAxis("Vertical");
        sideInput = Input.GetAxis("Horizontal");

        car.AddRelativeForce(Vector3.forward * forwardInput * driveSpeed, ForceMode.Acceleration);
        car.AddTorque(Vector3.up * sideInput * turnSpeed, ForceMode.Acceleration);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            EnableOverheat();
        }
        else
        {
            DisableOverheat();
        }
    }

    private void DisableOverheat()
    {
        Overheat(leftSteamSmoke, DisableOverheatColor);
        Overheat(rightSteamSmoke, DisableOverheatColor);

        Overheat(leftSmoke, DisableOverheatColor);
        Overheat(rightSmoke, DisableOverheatColor);
    }

    private void EnableOverheat()
    {
        Overheat(leftSteamSmoke, EnabledOverheatSteamColor);
        Overheat(rightSteamSmoke, EnabledOverheatSteamColor);

        Overheat(leftSmoke, EnabledOverheatColor);
        Overheat(rightSmoke, EnabledOverheatColor);
    }

    private void Overheat(ParticleSystem smoke, Color color)
    {
        ParticleSystem.MainModule mainModule = smoke.main;
        mainModule.startColor = color;
    }
}
