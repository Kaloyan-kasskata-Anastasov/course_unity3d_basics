using UnityEngine;
using UnityEngine.Events;

public class ColliderDetector : MonoBehaviour
{
    public UnityEvent<GameObject> onGateTrigger;

    public UnityEvent onCollisionEnter;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Gate"))
        {
            onGateTrigger.Invoke(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        onCollisionEnter.Invoke();
    }
}
