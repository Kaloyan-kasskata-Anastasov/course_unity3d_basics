using System.Collections.Generic;
using UnityEngine;

public class GatesController : MonoBehaviour
{
    public GameObject gatePrefab;

    private List<Gate> gatesPool;

    public void Awake()
    {
        gatesPool = new List<Gate>();
    }

    public Gate SpawnNext(Vector3 position, Quaternion rotation)
    {
        Gate gate = GetAvailable();

        gate.transform.position = position;
        gate.transform.rotation = rotation;
        gate.GameObject.SetActive(true);
        gate.ToggleFlames(true);

        return gate;
    }

    private Gate GetAvailable()
    {
        Gate found = gatesPool.Find(x => !x.GameObject.activeSelf);
        if (found == null)
        {
            found = Instantiate(gatePrefab).GetComponent<Gate>();
            found.Transform.parent = transform;
            gatesPool.Add(found);
            found.name = $"№{gatesPool.Count}";
        }

        return found;
    }

    public void Disable(Gate gate)
    {
        gate.ToggleFlames(false);
    }
}
