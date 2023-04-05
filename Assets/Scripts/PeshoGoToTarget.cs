using UnityEngine;

public class PeshoGoToTarget : MonoBehaviour
{
    public float walingSpeed;
    public Transform target;

    public Animator animator;

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
        {
            transform.LookAt(target);
            transform.position += transform.forward * walingSpeed * Time.deltaTime;
        }
    }
    
    public void Ride()
    {
        target.GetComponent<CarController>().IsDriverInTheCar = true;
        Destroy(gameObject);
    }
}