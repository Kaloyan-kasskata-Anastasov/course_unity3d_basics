using UnityEngine;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

public class CarScript : MonoBehaviour
{
    public float Speed = 10f;

    public float MinZ = -1.7f;
    public float MaxZ = 10f;

    public static int Health = 5;

    public Slider Healthbar;
    public GameObject GameOverMenu;
    public RoadScript RoadScript;

    float _horizontalAxis;
    float _verticalAxis;

    // Use this to move the car forward/backward and left/right
    private Rigidbody _rigidbody;

    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        // Detect hit with either tag "Health" or tag "Enemy"
        if (collider.tag == "Health")
        {
            Health++;
        }
        else if (collider.tag == "Enemy")
        {
            Health--;
        }

        Healthbar.value = Health;
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            // GameOver
            RoadScript.RoadSpeed = 0f;
            GameOverMenu.SetActive(true);
        }
        else
        {
            _verticalAxis = Input.GetAxis("Vertical");
            _horizontalAxis = Input.GetAxis("Horizontal");

            Vector3 movement = new Vector3(_horizontalAxis, 0f, _verticalAxis);

            transform.Translate(movement * Speed * Time.deltaTime);

            if (MinZ > transform.position.z)
            {
                transform.position = new Vector3(transform.position.x,
                    transform.position.y,
                    MinZ);
            }

            if (MaxZ < transform.position.z)
            {
                transform.position = new Vector3(transform.position.x,
                    transform.position.y,
                    MaxZ);
            }
        }
    }
}
