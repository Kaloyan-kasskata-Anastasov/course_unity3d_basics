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

    public void Start()
    {
        car = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
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
        Overheat(leftSteamSmoke, this.DisableOverheatColor);
        Overheat(rightSteamSmoke, this.DisableOverheatColor);

        Overheat(rightSmoke, this.DisableOverheatColor);
        Overheat(rightSmoke, this.DisableOverheatColor);
    }

    private void EnableOverheat()
    {
        Overheat(leftSteamSmoke, this.EnabledOverheatSteamColor);
        Overheat(rightSteamSmoke, this.EnabledOverheatSteamColor);

        Overheat(leftSmoke, this.EnabledOverheatColor);
        Overheat(rightSmoke, this.EnabledOverheatColor);
    }

    private void Overheat(ParticleSystem smoke, Color color)
    {
        ParticleSystem.MainModule mainModule = smoke.main;
        mainModule.startColor = color;
    }
}
