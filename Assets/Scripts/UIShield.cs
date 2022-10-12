using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class UIShield : MonoBehaviour
{	
	public event Action<float> SpawnDelayChanged;
	public event Action<float> SpeedChanged;
	public event Action<float> DistanceChanged;

	InputField spawnDelayField;
	InputField speedField;
	InputField distanceField;

	float cachedSpawnDelay;
	float cachedSpeed;
	float cachedDistance;

	void Awake ()
	{
		cachedSpawnDelay = Consts.Spawner.DEFAULT_SPAWN_DELAY;
		cachedSpeed = Consts.Spawner.DEFAULT_CUBE_SPEED;
		cachedDistance = Consts.Spawner.DEFAULT_DESTROY_DISTANCE;
		
		spawnDelayField = transform.GetChildComponent<InputField>("Canvas/InputField_SpawnDelay");
		spawnDelayField.onSubmit.AddListener(delegate { OnSpawnDelayChanged(); } );
		spawnDelayField.text = cachedSpawnDelay.ToString(CultureInfo.InvariantCulture);

		speedField = transform.GetChildComponent<InputField>("Canvas/InputField_Speed");
		speedField.onSubmit.AddListener(delegate { OnSpeedChanged(); } );
		speedField.text = cachedSpeed.ToString(CultureInfo.InvariantCulture);

		distanceField = transform.GetChildComponent<InputField>("Canvas/InputField_Distance");
		distanceField.onSubmit.AddListener(delegate { OnDistanceChanged(); } );
		distanceField.text = cachedDistance.ToString(CultureInfo.InvariantCulture);
	}

	bool TryConvert (string text, float min, float max, out float result)
	{
		if (Parser.TryParse(text, out result))
		{
			result = result.ForceClamp(min, max);
			return true;
		}
		else
		{
			result = min;
			return false;
		}
	}

	void OnSpawnDelayChanged ()
	{
		if (TryConvert(spawnDelayField.text, Consts.Spawner.MIN_SPAWN_DELAY, float.MaxValue, out float result)
		  && result != cachedSpawnDelay)
		{
			cachedSpawnDelay = result;
			SpawnDelayChanged(result);
		}
		spawnDelayField.text = cachedSpawnDelay.ToString(CultureInfo.InvariantCulture);
	}

	void OnSpeedChanged ()
	{
		if (TryConvert(speedField.text, 0.0f, float.MaxValue, out float result)
		  && result != cachedSpeed)
		{
			cachedSpeed = result;
			SpeedChanged(result);
		}
		speedField.text = cachedSpeed.ToString(CultureInfo.InvariantCulture);
	}

	void OnDistanceChanged ()
	{
		if (TryConvert(distanceField.text, 0.0f, float.MaxValue, out float result)
		  && result != cachedDistance)
		{
			cachedDistance = result;
			DistanceChanged(result);
		}
		distanceField.text = cachedDistance.ToString(CultureInfo.InvariantCulture);
	}
}
