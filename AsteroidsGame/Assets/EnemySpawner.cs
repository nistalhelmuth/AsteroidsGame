using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	// Use this for initialization

	public GameObject asteroidPrefab;
	public float SpawnTime = 4f;
	private float next = 3f;
	public float decay = 0.90f;

	// Update is called once per frame
	void Update () {

		if (next > 0)
			next = next - Time.deltaTime;
		else {
			next = next + SpawnTime;
			SpawnTime = SpawnTime * decay; 
			Quaternion angulo = Quaternion.Euler (0, 0, Random.Range (0f, 360f));       
			GameObject asteroide = Instantiate (asteroidPrefab, new Vector3(0,20,0), new Quaternion()) as GameObject;
			asteroide.transform.RotateAround (Vector3.zero, Vector3.forward, Random.Range (0f, 360f));
		}

	}
}
