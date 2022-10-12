using UnityEngine;

public class App : MonoBehaviour
{
	CubeSpawner spawner;
	UIShield ui;

	void Awake ()
	{
		spawner = transform.GetChildComponent<CubeSpawner>("CubeSpawner");
		ui = transform.GetChildComponent<UIShield>("UI");

		ui.SpeedChanged += OnSpeedChanged;
		ui.SpawnDelayChanged += OnSpawnDelayChanged;
		ui.DistanceChanged += OnDistanceChanged;
	}

	void OnDestroy ()
	{
		ui.SpeedChanged -= OnSpeedChanged;
		ui.SpawnDelayChanged -= OnSpawnDelayChanged;
		ui.DistanceChanged -= OnDistanceChanged;
	}

	void OnSpeedChanged (float speed)
	{
		spawner.Speed = speed;
	}

	void OnSpawnDelayChanged (float spawnDelay)
	{
		spawner.SpawnDelay = spawnDelay;
	}

	void OnDistanceChanged (float distance)
	{
		spawner.Distance = distance;
	}
}
