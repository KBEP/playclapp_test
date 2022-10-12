using UnityEngine;

public class Cube : MonoBehaviour
{
	Vector3 startPos;
	float speed;
	float sqrDestroyDistance;

	public void Setup (float speed, float destroyDistance)
	{
		this.speed = speed.Positivize();
		sqrDestroyDistance = (destroyDistance * destroyDistance).Positivize();
	}

	void Start ()
	{
		startPos = transform.position;
	}

	void Update ()
	{
		transform.Translate(Vector3.forward * Time.deltaTime * speed);

		if (Vector3.SqrMagnitude(transform.position - startPos) >= sqrDestroyDistance) Destroy(gameObject);
	}
}
