using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;
    public Vector3 Position = new Vector3(0, 5, 10);
    public bool freezeY = true;
    public bool lookTarget = true;
    private Transform transformCached;
    private Vector3 currentPosition;

    public void Awake()
    {
        transformCached = transform;
    }

    public void LateUpdate()
    {
        if (freezeY)
        {
            currentPosition.x = target.position.x - Position.x;
            currentPosition.y = transformCached.position.y;
            currentPosition.z = target.position.z - Position.z;
        }
        else
        {
            currentPosition = target.position - Position;
        }

        transformCached.position = currentPosition;

        if (lookTarget)
        {
            transformCached.LookAt(target);
        }
    }
}
