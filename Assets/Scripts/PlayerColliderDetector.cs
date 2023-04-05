using System;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

public class PlayerColliderDetector : MonoBehaviour
{
    public const string ObstacleString = "Obstacle";
    public const string FuelBarrelString = "FuelBarrel";
    public const string GameOverBorderString = "GameOverBorder";

    [SerializeField]
    private UnityEvent<string> onObstacleHit;

    [SerializeField]
    private UnityEvent onEnterGameOverBorder;

    [SerializeField]
    private UnityTransformEvent onHealthBarrelHit;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Contains(ObstacleString))
        {
            onObstacleHit.Invoke(collision.gameObject.name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains(GameOverBorderString))
        {
            onEnterGameOverBorder.Invoke();
        }

        if (other.gameObject.name.Contains(FuelBarrelString))
        {
            onHealthBarrelHit.Invoke(other.GetComponent<Object>());
        }
    }

    [Serializable]
    public class UnityTransformEvent : UnityEvent<Object>
    {}
}
