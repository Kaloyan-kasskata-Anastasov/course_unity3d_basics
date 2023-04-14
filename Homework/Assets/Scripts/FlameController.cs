using UnityEngine;

public class FlameController : MonoBehaviour
{
    public ParticleSystem leftFlame;
    public ParticleSystem rightFlame;

    public void ToggleFlames(bool playing)
    {
        ParticleSystem.EmissionModule emission = this.leftFlame.emission;
        emission.enabled = playing;

        emission = this.rightFlame.emission;
        emission.enabled = playing;
    }
}
