using UnityEngine;

public class Raycaster : MonoBehaviour
{
    public void Update()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10))
        {
            Vector3 randomVector = new Vector3(GetRandom(), GetRandom(), GetRandom());
            var body = hit.transform.GetComponent<Rigidbody>();
            if (body != null)
            {
                body.AddExplosionForce(500, hit.transform.position + randomVector, 10);
            }
        }
    }

    private float GetRandom()
    {
        return Random.Range(0.1f, 1f);
    }
}
