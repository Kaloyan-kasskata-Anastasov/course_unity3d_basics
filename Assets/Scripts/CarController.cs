using UnityEngine;

public class CarController : MonoBehaviour
{
    private const string VerticalAxisString = "Vertical";
    private const string HorizontalAxisString = "Horizontal";
    private float forwardInput;
    private float sideInput;

    public int driveSpeed;
    public int turnSpeed;
    public int overheatBonusSpeed;

    public ParticleSystem leftSteamSmoke;
    public ParticleSystem rightSteamSmoke;
    public ParticleSystem leftSmoke;
    public ParticleSystem rightSmoke;

    public Color disabledOverheatColor = Color.gray;
    public Color enabledOverheatSteamColor = Color.yellow;
    public Color enabledOverheatColor = Color.red;

    public Rigidbody Rigidbody { get; private set; }

    public void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        if (GameManager.PlayState != GameManager.GameState.Playing)
        {
            return;
        }

        forwardInput = Input.GetAxis(VerticalAxisString);
        sideInput = Input.GetAxis(HorizontalAxisString);

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
        Overheat(leftSteamSmoke, disabledOverheatColor);
        Overheat(rightSteamSmoke, disabledOverheatColor);

        Overheat(leftSmoke, disabledOverheatColor);
        Overheat(rightSmoke, disabledOverheatColor);
    }

    private void EnableOverheat()
    {
        driveSpeed += overheatBonusSpeed;
        Overheat(leftSteamSmoke, enabledOverheatSteamColor);
        Overheat(rightSteamSmoke, enabledOverheatSteamColor);

        Overheat(leftSmoke, enabledOverheatColor);
        Overheat(rightSmoke, enabledOverheatColor);
    }

    private void Overheat(ParticleSystem smoke, Color color)
    {
        ParticleSystem.MainModule mainModule = smoke.main;
        mainModule.startColor = color;
    }
}
