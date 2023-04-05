using UnityEngine;

public class ColliderDetector : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Crate"))
        {
            Debug.Log($"{collision.gameObject.name} Hit!");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name.Contains("Crate"))
        {
            Debug.Log($"{collision.gameObject.name} is just a roadkill!");
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "GameOverBorder")
        {
            Debug.Log($"{collider.gameObject.name} DIED");
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.name == "GameOverBorder")
        {
            Debug.Log($"{collider.gameObject.name} is lost forever!");
        }
    }
}
