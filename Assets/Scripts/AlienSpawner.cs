using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AlienSpawner : MonoBehaviour {
    private float _timer;
    
    public float spawnTimer = 1f;
    
    void Start() {
        _timer = spawnTimer;
    }


    void Update() {
        if (Math.Abs(_timer - spawnTimer) < 0.001f) {
            var x = Random.Range(-1.3f, 2.3f);
            var alien = ObjectPooler.SharedInstance.GetPooledObject(13);
            alien.transform.position = new Vector3(x, 6, 0); 
            alien.SetActive(true);
        }
        
        _timer -= Time.deltaTime;

        if (_timer < 0) {
            _timer = spawnTimer;
        }
    }
}