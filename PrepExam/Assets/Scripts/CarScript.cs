using UnityEngine;
using System.Collections;

public class CarScript : MonoBehaviour
{
    public static bool IsAlive;

    public GuiManager GuiManager;
    public GameObject Explosion;
    private float _moveSpeed = 5f;
    private float _zMax = 7.19f;
    private float _zMin = 1.61f;
    private float _xMin = 10.53f;
    private float _xMax = 18.36f;
    private float _yCoordinate = 0.415f;
    public int Score;
    float _gameTime;

    private AudioSource coinAudio;

    // Use this for initialization
    void Start()
    {
        IsAlive = true;
        Score = PlayerPrefs.GetInt("Score", 0);
        GuiManager.ScoreLbl.text = string.Format("Score : {0}", Score.ToString());
        _gameTime = 0f;
        coinAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAlive)
        {
            var _verticalAxis = Input.GetAxis("Vertical");
            var _horizontalAxis = Input.GetAxis("Horizontal");

            Vector3 movement = new Vector3(_horizontalAxis, 0f, _verticalAxis);

            transform.Translate(movement * _moveSpeed * Time.deltaTime);

            if (_zMin > transform.position.z)
            {
                transform.position = new Vector3(transform.position.x,
                    transform.position.y,
                    _zMin);
            }

            if (_zMax < transform.position.z)
            {
                transform.position = new Vector3(transform.position.x,
                    transform.position.y,
                    _zMax);
            }

            if (_xMin > transform.position.x)
            {
                transform.position = new Vector3(_xMin,
                    transform.position.y,
                    transform.position.z);
            }

            if (_xMax < transform.position.x)
            {
                transform.position = new Vector3(_xMax,
                    transform.position.y,
                    transform.position.z);
            }

            ManageSensitivity();
        }
    }

    void ManageSensitivity()
    {
        if (Time.timeSinceLevelLoad > (_gameTime + 15))
        {
            _gameTime += 15;
            _moveSpeed += 0.01f;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            Crash();
            col.gameObject.SetActive(false);
        }
        else if (col.tag == "Coin")
        {
            col.gameObject.SetActive(false);
            Score += 1;
            GuiManager.ScoreLbl.text = $"Score: {Score}";
            coinAudio.Play();
        }
        else if (col.tag == "GreenCoin")
        {
            col.gameObject.SetActive(false);
            Score += 2;
            GuiManager.ScoreLbl.text = $"Score: {Score}";
            coinAudio.Play();
        }
    }

    void Crash()
    {
        gameObject.SetActive(false);
        Explosion.SetActive(true);
        IsAlive = false;
        GuiManager.ShowDeadText();
    }
}
