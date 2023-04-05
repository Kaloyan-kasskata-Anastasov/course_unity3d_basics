using System;
using UnityEngine;
using UnityEngine.Events;

public class Pesho : MonoBehaviour
{
    public float walkingSpeed;

    public Animator animator;
    public UnityEvent onRide;
    public Func<Transform> onLookForTarget;
    private Transform target;

    void LateUpdate()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
        {
            if (target == null)
            {
                target = onLookForTarget?.Invoke();
            }

            transform.LookAt(target);
            transform.position += transform.forward * walkingSpeed * Time.deltaTime;
        }
    }
    
    public void Ride()
    {
        onRide.Invoke();
        Destroy(gameObject);
    }
}