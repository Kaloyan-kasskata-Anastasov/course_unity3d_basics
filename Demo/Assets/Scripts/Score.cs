using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Sprite[] digits;
    public Text scoreText;
    private Image[] numberScore;
    public Animation scoreAnim;

    public void Awake()
    {
        numberScore = transform.GetComponentsInChildren<Image>();
        scoreAnim = GetComponent<Animation>();
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

    public void AnimateScore(int value)
    {
        scoreText.color = value <= 0 ?
            Color.red : 
            Color.green;

        scoreAnim.Play();
    }

    public void ReturnColor()
    {
        scoreText.color = Color.white;
    }
}
