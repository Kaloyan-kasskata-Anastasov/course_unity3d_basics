using UnityEngine;

public class HealthContainer : MonoBehaviour
{
    public TextMesh healthAmountText;

    public uint FuelAmount;

    public void UpdateFuelAmount(uint fuelAmount)
    {
        FuelAmount = fuelAmount;
        healthAmountText.text = $"Fuel + {FuelAmount}";
    }
}
