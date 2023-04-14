using UnityEngine;

public class ColliderDetector : MonoBehaviour
{
    public UI gameUI;

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
        other.GetComponent<FlameController>().ToggleFlames(false);

        int index = other.transform.GetSiblingIndex();

        if (other.transform.parent.childCount > index + 1)
        {
            Transform nextNode = other.transform.parent.GetChild(index + 1);
            if (nextNode)
            {
                nextNode.transform.GetComponent<FlameController>().ToggleFlames(true);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameUI.ShowGameOverScreenDeath();
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
