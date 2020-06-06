using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroid : MonoBehaviour {
    public float speed = 0.06f;
    
    private float _rotationSpeed;
    private float _torqueSpeed;


    void Start() {
        var scale = Random.Range(0.3f, 0.5f);
        var size = transform.localScale;
        transform.localScale = new Vector3(size.x * scale, size.y * scale, size.z * scale);

        _rotationSpeed = Random.Range(-5, 5);
        _torqueSpeed = Random.Range(-0.005f, 0.005f);
    }

    void FixedUpdate() {
        transform.position += Vector3.down * speed;
        transform.position += Vector3.left * _torqueSpeed;

        transform.Rotate(0, 0, _rotationSpeed);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Laser")) {
            col.gameObject.SetActive(false);
            ScoreCounter.Score++;
            
            var explosion = ObjectPooler.SharedInstance.GetPooledObject(12);
            explosion.transform.position = transform.position;
            explosion.SetActive(true);

            gameObject.SetActive(false);
        }
    }
}