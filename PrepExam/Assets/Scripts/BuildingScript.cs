using UnityEngine;

public class BuildingScript : MonoBehaviour
{
    private float _resetDistance = 202f;
    private float _resetCoordinateZ = -20.44f;
    private float Speed = -15f;


    // Update is called once per frame
    void Update()
    {
        if (CarScript.IsAlive)
        {
            transform.Translate(transform.InverseTransformDirection(Vector3.forward) * Speed * Time.deltaTime);
            if (transform.position.z <= _resetCoordinateZ)
            {
                transform.Translate(transform.InverseTransformDirection(Vector3.forward) * _resetDistance);
            }
        }
    }
}
