using System.Collections;
using UnityEngine;

public class DriverAI : MonoBehaviour
{
    private Rigidbody body;
    private Coroutine moveCoroutine;
    public float speed = 10;
    public bool IsAlive { get; set; } = true;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
        moveCoroutine = StartCoroutine(MoveCoroutine());
    }

    public void OnDestroy()
    {
        StopCoroutine(moveCoroutine);
        moveCoroutine = null;
    }

    private IEnumerator MoveCoroutine()
    {
        while (IsAlive)
        {
            body.AddRelativeForce(new Vector3(0, 0, speed), ForceMode.Acceleration);
            yield return new WaitForFixedUpdate();
        }
    }
}
