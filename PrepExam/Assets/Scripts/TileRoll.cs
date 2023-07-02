using UnityEngine;

public class TileRoll : MonoBehaviour
{
	// Scroll main texture based on time
	public MapGenerator MapGenerator;
	public float SpeedMultiplier = 0.2f;
	private Renderer _rend;

	void Start()
	{
		_rend = GetComponent<Renderer>();
	}

	void Update()
	{
		if (MapGenerator == null)
		{
			return;
		}

		var offset = -Time.time * MapGenerator.MapSpeed * SpeedMultiplier;
		_rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
	}
}
