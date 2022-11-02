using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour {
    [SerializeField] private float spawnTimer = 3f;
    
    private float _timer;

    private void Start() {
        _timer = 5f;
    }

    private void FixedUpdate() {
        if (Math.Abs(_timer - spawnTimer) < 0.001f) {
            var xCoord = Random.Range(-2.4f, 2.4f);
            var coin = ObjectPooler.SharedInstance.GetPooledObject(20);
            coin.transform.position = new Vector3(xCoord, 6, 0); 
            coin.SetActive(true);
        }
        
        _timer -= Time.deltaTime;

        if (_timer < 0) {
            _timer = spawnTimer;
        }
    }
}