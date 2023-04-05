using UnityEngine;

public class CarController : MonoBehaviour
{
    private float forwardInput;
    private float sideInput;

    public int driveSpeed;
    public int turnSpeed;
    public int overheatBonusSpeed;

    public ParticleSystem leftSteamSmoke;
    public ParticleSystem rightSteamSmoke;
    public ParticleSystem leftSmoke;
    public ParticleSystem rightSmoke;

    public Color DisableOverheatColor = Color.gray;
    public Color EnabledOverheatSteamColor = Color.yellow;
    public Color EnabledOverheatColor = Color.red;

    public bool IsDriverInTheCar;

    public Rigidbody Rigidbody { get; private set; }

    public void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        if (IsDriverInTheCar == false)
        {
            return;
        }

        forwardInput = Input.GetAxis("Vertical");
        sideInput = Input.GetAxis("Horizontal");

        Rigidbody.AddRelativeForce(Vector3.forward * forwardInput * driveSpeed, ForceMode.Acceleration);
        Rigidbody.AddTorque(Vector3.up * sideInput * turnSpeed, ForceMode.Acceleration);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            EnableOverheat();
        }
        
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            DisableOverheat();
        }
    }

    private void DisableOverheat()
    {
        driveSpeed -= overheatBonusSpeed;
        Overheat(leftSteamSmoke, DisableOverheatColor);
        Overheat(rightSteamSmoke, DisableOverheatColor);

        Overheat(leftSmoke, DisableOverheatColor);
        Overheat(rightSmoke, DisableOverheatColor);
    }

    private void EnableOverheat()
    {
        driveSpeed += overheatBonusSpeed;
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
