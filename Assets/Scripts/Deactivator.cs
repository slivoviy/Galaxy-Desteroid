using UnityEngine;

public class Deactivator : MonoBehaviour {
    private void OnTriggerExit2D(Collider2D col) {
        col.gameObject.SetActive(false);
    }
}