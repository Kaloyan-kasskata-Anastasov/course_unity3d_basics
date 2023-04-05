using UnityEngine;
using UnityEngine.InputSystem;

public class CarLightsController : MonoBehaviour
{
    public InputAction lightInput;
    private Light[] lights;

    public void Awake()
    {
        lights = transform.GetComponentsInChildren<Light>();

        lightInput.performed += context =>
        {
            foreach (Light carLight in lights)
            {
                carLight.enabled = !carLight.enabled;
            }
        };
    }
}
