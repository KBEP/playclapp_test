using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
	float spawnDelay = Consts.Spawner.DEFAULT_SPAWN_DELAY;
	float speed = Consts.Spawner.DEFAULT_CUBE_SPEED;
	float distance = Consts.Spawner.DEFAULT_DESTROY_DISTANCE;
	float lastSpawnTime;

	public float SpawnDelay
	{
		get => spawnDelay;
		set => spawnDelay = Mathf.Clamp(value.Positivize(), Consts.Spawner.MIN_SPAWN_DELAY, float.MaxValue);
	}

	public float Speed
	{
		get => speed;
		set => speed = value.Positivize();
	}

	public float Distance
	{
		get => distance;
		set => distance = value.Positivize();
	}

	void OnEnable ()
	{
		lastSpawnTime = Time.time;
	}

	void Update ()
	{
		while (lastSpawnTime + spawnDelay <= Time.time)
		{
			Spawn();
			lastSpawnTime += spawnDelay;
		}
	}

	void Spawn ()
	{
		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.position = RandomPosition();//transform.position;
		Cube c = cube.AddComponent<Cube>();
		c.Setup(speed, distance);
	}

	Vector3 RandomPosition ()
	{
		float offset = Random.Range(-3.0f, 3.0f);
		return new Vector3(transform.position.x + offset, transform.position.y, transform.position.z);
	}
}
