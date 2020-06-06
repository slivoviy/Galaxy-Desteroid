using System;
using System.Collections;
using UnityEngine;

public class BackgroundLoopScript : MonoBehaviour {
    
    public GameObject background;
    private float _speed = -0.06f;

    private void Start() {
        StartCoroutine(InstantiateBackground());
        
        StartCoroutine(DestroyBackground());
    }

    void FixedUpdate() {
        
        transform.Translate(new Vector3(0f, _speed, 0f));
    }

    private IEnumerator InstantiateBackground() {
        yield return new WaitUntil(() => Math.Abs(transform.position.y - (-15f)) < 0.1);
        
        Instantiate(background, new Vector3(0f, 24.9f, 0f), Quaternion.Euler(0, 0, 0));
    }

    private IEnumerator DestroyBackground() {
        yield return new WaitUntil(() => transform.position.y < -25f);
        
        Destroy(gameObject);
    }
}