using System;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Sprite[] digits;
    private Image[] numberScore;

    public void Awake()
    {
        numberScore = transform.GetComponentsInChildren<Image>();
    }

    public void UpdateScore(uint value)
    {
        string number = Mathf.Clamp(value, 0f, 9999f).ToString("0000");
        for (int i = 0; i < number.Length; i++)
        {
            int digit = number[i] - '0';
            numberScore[i].sprite = digits[digit];
        }
    }

}
