using UnityEngine;

public class PlaneAudio : MonoBehaviour
{
    public bool IsDead { get; set; }
    public float minPitchEngine;
    private AudioSource source;

    public void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (IsDead)
        {
            if (source.pitch >= minPitchEngine)
            {
                source.pitch -= Time.deltaTime;
            }
        }
    }
}
