using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Alien : MonoBehaviour {
    [SerializeField] private float speed = 0.08f;
    [SerializeField] private float xSpeed = 0.08f;
    [SerializeField] private float fireRate = 1.5f;
    
    private float _startX;
    private float _timer;
    private bool _moveLeft;

    private void Start() {
        _startX = transform.position.x;
        _moveLeft = true;
        _timer = 2.5f;
    }

    private void OnEnable() {
        _startX = transform.position.x;
        _moveLeft = true;
    }

    private void FixedUpdate() {
        transform.position += Vector3.down * speed;

        if (_moveLeft) {
            transform.position += Vector3.left * xSpeed;
            if (Math.Abs(transform.position.x - (_startX - 1f)) < 0.1) {
                _moveLeft = false;
            }
        }
        else {
            transform.position += Vector3.right * xSpeed;
            if (Math.Abs(transform.position.x - (_startX)) < 0.1) {
                _moveLeft = true;
            }
        }
        
        
        if (_timer < 0) {
            _timer = fireRate;
        }

        if (Math.Abs(_timer - fireRate) < 0.001) {
            var shot = ObjectPooler.SharedInstance.GetPooledObject(14);
            var t = transform.position;
            shot.transform.position = new Vector2(t.x, t.y + 0.15f);
            shot.transform.rotation = transform.rotation;
            shot.SetActive(true);
        }
        
        _timer -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (!col.CompareTag("Laser")) return;
        
        col.gameObject.SetActive(false);

        var explosion = ObjectPooler.SharedInstance.GetPooledObject(12);
        explosion.transform.position = transform.position;
        explosion.SetActive(true);

        gameObject.SetActive(false);
            
        DropAGun();
    }

    private void DropAGun() {
        var rand = Random.Range(1, 50);
        if (rand > 10) return;
        
        GameObject droppedItem;
        switch (rand) {
            case 1:
                droppedItem = ObjectPooler.SharedInstance.GetPooledObject(15);
                break;
            case 2:
                droppedItem = ObjectPooler.SharedInstance.GetPooledObject(16);
                break;
            case 3:
                droppedItem = ObjectPooler.SharedInstance.GetPooledObject(17);
                break;
            case 4:
                droppedItem = ObjectPooler.SharedInstance.GetPooledObject(18);
                break;
            case 5:
                droppedItem = ObjectPooler.SharedInstance.GetPooledObject(19);
                break;
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
                droppedItem = ObjectPooler.SharedInstance.GetPooledObject(20);
                break;
            default:
                droppedItem = ObjectPooler.SharedInstance.GetPooledObject(12);
                break;
        }

        droppedItem.transform.position = transform.position;
        droppedItem.SetActive(true);
    }
}