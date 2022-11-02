using System;
using UnityEngine;

public class BigGun : MonoBehaviour {
    [SerializeField] private GameObject[] smallGuns;
    
    private Vector3[] _smallGunPositions;
    private bool _active;

    private void Awake() {
        _active = true;
        _smallGunPositions = new Vector3[smallGuns.Length];
        for (var i = 0; i < smallGuns.Length; ++i) {
            _smallGunPositions[i] = smallGuns[i].transform.localPosition;
        }
    }

    private void OnEnable() {
        for(var i = 0; i < smallGuns.Length; ++i) {
            smallGuns[i].transform.localPosition = _smallGunPositions[i];
            smallGuns[i].SetActive(true);
        }
    }

    void FixedUpdate() {
        _active = false;
        foreach (var smallGun in smallGuns) {
            if (smallGun.activeInHierarchy) {
                _active = true;
            }
        }

        if (!_active) {
            gameObject.SetActive(false);
        }
    }
}