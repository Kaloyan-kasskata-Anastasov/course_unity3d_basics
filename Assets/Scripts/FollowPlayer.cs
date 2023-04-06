using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject plane;
    private Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = plane.transform.position + offset;
    }
}
