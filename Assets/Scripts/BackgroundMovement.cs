using System;
using System.Collections;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour {
    private const float Speed = -0.06f;
    
    [SerializeField] private GameObject background;

    private void Start() {
        StartCoroutine(InstantiateBackground());
        
        StartCoroutine(DestroyBackground());
    }

    private void FixedUpdate() {
        
        transform.Translate(new Vector3(0f, Speed, 0f));
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