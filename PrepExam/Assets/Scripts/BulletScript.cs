using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 0.4f;
    float outOfScreenValueMax = 60f;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed;

        if (transform.position.z > outOfScreenValueMax)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter(Collider coll)
    {
        Destroy(this.gameObject);
    }
}
