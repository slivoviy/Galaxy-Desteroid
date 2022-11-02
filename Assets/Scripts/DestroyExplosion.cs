using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExplosion : MonoBehaviour {
    private void Update() {
        StartCoroutine(DestroyItself());
    }

    private IEnumerator DestroyItself() {
        yield return new WaitForSeconds(0.8f);
        
        gameObject.SetActive(false);
    }
}