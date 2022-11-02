using UnityEngine;

public class MoveController : MonoBehaviour {

    [SerializeField] private float speed = 0.5f;

    private void FixedUpdate() {
        transform.position += Vector3.up * speed;
    }
}