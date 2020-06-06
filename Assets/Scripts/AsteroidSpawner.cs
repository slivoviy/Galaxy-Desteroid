using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawner : MonoBehaviour {
    private float _timer;

    public float spawnTimer = 0.5f;

    void Start() {
        _timer = spawnTimer;
    }

    void FixedUpdate() {
        if (Math.Abs(_timer - spawnTimer) < 0.001f) {
            var x = Random.Range(-2.5f, 2.5f);
            var asteroid = ObjectPooler.SharedInstance.GetPooledObject(Random.Range(0, 6));
            asteroid.transform.position = new Vector3(x, 6, 0); 
            asteroid.SetActive(true);
        }
        
        _timer -= Time.deltaTime;

        if (_timer < 0) {
            _timer = spawnTimer;
        }
    }
}