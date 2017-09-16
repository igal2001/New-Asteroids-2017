using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject asteroidPrefab;
    public float spawnDelay = 5f;
    public float decay = 0.95f;
    private float next = 3f;
	
	
	void Update () {
        if (next > 0) next = next - Time.deltaTime;
        else
        {
            next = next + spawnDelay;
            spawnDelay = spawnDelay * decay;
            Quaternion angle = Quaternion.Euler(0, 0, Random.Range(0f, 350f));
            GameObject asteroid = Instantiate(asteroidPrefab, new Vector2(0, 20), angle) as GameObject;
            asteroid.transform.RotateAround(Vector2.zero, Vector3.forward, Random.Range(0f, 350f));
        }
	}
}
