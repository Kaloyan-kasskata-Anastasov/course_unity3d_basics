using UnityEngine;

public class ColliderDetector : MonoBehaviour
{
    public UI gameUI;
    public PlaneAudio planeAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Gate"))
        {
            gameUI.UpdateTimer();
            gameUI.UpdateGateCounter();

            UpdateFlames(other);
        }
    }

    private void UpdateFlames(Collider other)
    {
        other.transform.parent.GetComponent<FlameController>().ToggleFlames(false);
        other.transform.parent.GetComponent<Animation>().Stop();

        int index = other.transform.parent.GetSiblingIndex();

        if (other.transform.parent.parent.childCount > index + 1)
        {
            index += 1;
            Transform nextGate = other.transform.parent.parent.GetChild(index);
            if (nextGate)
            {
                nextGate.GetComponent<FlameController>().ToggleFlames(true);
                nextGate.GetComponent<Animation>().Play();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameUI.ShowGameOverScreenDeath();
        planeAudio.IsDead = true;
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
        }
    }
}
