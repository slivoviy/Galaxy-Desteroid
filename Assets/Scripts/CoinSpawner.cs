using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour {
    private float _timer;

    public float spawnTimer = 3f;

    void Start() {
        _timer = 5f;
    }

    void FixedUpdate() {
        if (Math.Abs(_timer - spawnTimer) < 0.001f) {
            var x = Random.Range(-2.4f, 2.4f);
            var coin = ObjectPooler.SharedInstance.GetPooledObject(20);
            coin.transform.position = new Vector3(x, 6, 0); 
            coin.SetActive(true);
        }
        
        _timer -= Time.deltaTime;

        if (_timer < 0) {
            _timer = spawnTimer;
        }
    }
}