using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class CarController : MonoBehaviour
{
    private float forwardInput;
    private float sideInput;

    public int driveSpeed;
    public int turnSpeed;
    public int overheatBonusSpeed;

    public InputAction horizontalInput;
    public InputAction verticalInput;
    public InputAction overheatInput;

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
        horizontalInput.performed += context => ProcessInput(context, ref sideInput);
        horizontalInput.canceled += context => ProcessInput(context, ref sideInput);

        verticalInput.performed += context => ProcessInput(context, ref forwardInput);
        verticalInput.canceled += context => ProcessInput(context, ref forwardInput);

        overheatInput.performed += ProcessOverheat;
        overheatInput.canceled += ProcessOverheat;
    }

    private void ProcessInput(InputAction.CallbackContext context, ref float input)
    {
        input = context.ReadValue<float>();
    }

    public void OnEnable()
    {
        horizontalInput.Enable();
        verticalInput.Enable();
        overheatInput.Enable();
    }

    public void OnDisable()
    {
        horizontalInput.Disable();
        verticalInput.Disable();
        overheatInput.Disable();
    }

    public void OnDestroy()
    {
        horizontalInput.Dispose();
        verticalInput.Dispose();
        overheatInput.Dispose();
    }

    private void ProcessOverheat(InputAction.CallbackContext context)
    {
        bool pressed = ((ButtonControl) context.control).isPressed;
        if (pressed)
        {
            EnableOverheat();
        }
        else
        {
            DisableOverheat();
        }
    }

    public void FixedUpdate()
    {
        if (GameManager.PlayState != GameManager.GameState.Playing)
        {
            return;
        }

        Rigidbody.AddRelativeForce(Vector3.forward * forwardInput * driveSpeed, ForceMode.Acceleration);
        Rigidbody.AddTorque(Vector3.up * sideInput * turnSpeed, ForceMode.Acceleration);
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
