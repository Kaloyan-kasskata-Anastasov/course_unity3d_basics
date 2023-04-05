using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerColliderDetector : MonoBehaviour
{
    public const string ObstacleString = "Obstacle";
    public const string FuelBarrelString = "FuelBarrel";
    public const string GameOverBorderString = "GameOverBorder";
    private const string RoadString = "Road";

    [SerializeField]
    private UnityEvent<string> onObstacleHit;    
    
    [SerializeField]
    private UnityEvent onNewRoadTrigger;

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
        if (other.name.Contains(GameOverBorderString))
        {
            onEnterGameOverBorder.Invoke();
        }
        else if (other.gameObject.name.Contains(FuelBarrelString))
        {
            HealthContainer a = other.GetComponent<HealthContainer>();
            onHealthBarrelHit.Invoke(a);
        }
        else if (other.gameObject.name.Contains(RoadString))
        {
            onNewRoadTrigger.Invoke();
            other.GetComponent<Collider>().enabled = false;
        }
    }

    [Serializable]
    public class UnityTransformEvent : UnityEvent<HealthContainer>
    {
    }
}
