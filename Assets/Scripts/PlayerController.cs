using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private int _currentGun;
    private int _ammo;
    private int _lifes = 3;

    private float _fireRate = 0.25f;
    private float _timer;

    public float speed = 2f;

    public GameObject hurtPanel;
    public GameObject[] lifeUI;

    void Start() {
        _timer = _fireRate;
        _currentGun = 0;
    }

    void FixedUpdate() {
        if (_timer < 0) {
            _timer = _fireRate;
        }

        if (Input.GetMouseButton(0)) {
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.y += 0.3f;
            var pausePosition = new Rect(0, Screen.height - 280, 175, 280);

            if (!pausePosition.Contains(Input.mousePosition)) {
                transform.position = Vector2.Lerp(transform.position, pos, speed * Time.deltaTime);

                if (Math.Abs(_timer - _fireRate) < 0.001) {
                    if (_currentGun == 0) {
                        var shot = ObjectPooler.SharedInstance.GetPooledObject(_currentGun + 6);
                        var t = transform.position;
                        shot.transform.position = new Vector2(t.x, t.y + 1.3f);
                        shot.SetActive(true);
                    }
                    else {
                        _ammo--;

                        if (_ammo == 0) {
                            _currentGun = 0;
                            _fireRate = 0.25f;
                        }

                        var shot = ObjectPooler.SharedInstance.GetPooledObject(_currentGun + 6);
                        var t = transform.position;
                        shot.transform.position = new Vector2(t.x, t.y + 1.3f);
                        shot.SetActive(true);
                    }
                }
            }
        }

        _timer -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D col) {
        int gun;
        bool isParsable = Int32.TryParse(col.tag, out gun);

        if (isParsable) {
            _currentGun = gun;
            switch (_currentGun) {
                case 1:
                    _fireRate = 0.25f;
                    _ammo = 85;
                    col.gameObject.SetActive(false);
                    break;
                case 2:
                    _fireRate = 1f;
                    _ammo = 30;
                    col.gameObject.SetActive(false);
                    break;
                case 3:
                    _fireRate = 1f;
                    _ammo = 15;
                    col.gameObject.SetActive(false);
                    break;
                case 4:
                    _fireRate = 0.1f;
                    _ammo = 100;
                    col.gameObject.SetActive(false);
                    break;
                case 5:
                    _fireRate = 0.1f;
                    _ammo = 50;
                    col.gameObject.SetActive(false);
                    break;
            }
        }

        else {
            if (col.CompareTag("Coin")) {
                CoinCounter.Coins++;
                col.gameObject.SetActive(false);
            }
            else if (!col.CompareTag("Deactivator")) {
                _lifes--;
                if (_lifes == 0) {
                    var score = PlayerPrefs.GetInt("score", 0);
                    if (ScoreCounter.Score > score) {
                        PlayerPrefs.SetInt("score", ScoreCounter.Score);
                    }

                    var coins = PlayerPrefs.GetInt("coins", 0);
                    PlayerPrefs.SetInt("coins", coins + CoinCounter.Coins);

                    StartCoroutine(ShowHurtPanel());
                    
                    lifeUI[_lifes].SetActive(false);
                    gameObject.SetActive(false);
                    var explosion = ObjectPooler.SharedInstance.GetPooledObject(12);
                    explosion.transform.position = transform.position;
                    explosion.SetActive(true);

                    if (!col.CompareTag("Alien Laser")) {
                        col.gameObject.SetActive(false);
                        var colExplosion = ObjectPooler.SharedInstance.GetPooledObject(12);
                        colExplosion.transform.position = col.transform.position;
                        colExplosion.SetActive(true);
                    }
                }
                else {
                    col.gameObject.SetActive(false);
                    var colExplosion = ObjectPooler.SharedInstance.GetPooledObject(12);
                    colExplosion.transform.position = col.transform.position;
                    colExplosion.SetActive(true);

                    lifeUI[_lifes].SetActive(false);

                    StartCoroutine(ShowHurtPanel());
                    
                }
            }
        }
    }

    private IEnumerator ShowHurtPanel() {
        hurtPanel.SetActive(true);
        
        yield return new WaitForSeconds(0.334f);

        hurtPanel.SetActive(false);
    }
}