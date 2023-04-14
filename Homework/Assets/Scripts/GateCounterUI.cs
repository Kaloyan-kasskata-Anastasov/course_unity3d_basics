using UnityEngine;
using UnityEngine.UI;

public class GateCounterUI : MonoBehaviour
{
    public Text text;
    public Slider slider;

    public void UpdateUI(int value, int maxGates)
    {
        slider.value = value;
        slider.minValue = 0;
        slider.maxValue = maxGates;
        text.text = $"{value} / {maxGates}";
    }

}
