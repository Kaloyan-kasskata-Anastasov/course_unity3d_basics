using UnityEngine;

public class ColliderDetector : MonoBehaviour
{
    public UI ui;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Crate"))
        {
            ui.UpdateScore(10);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "GameOverBorder")
        {
            ui.ShowGameOver();
        }

        if (collider.gameObject.name.Contains("HealthBarrel"))
        {
            ui.UpdateHealth(20);
            Destroy(collider.gameObject);
        }
    }
}
