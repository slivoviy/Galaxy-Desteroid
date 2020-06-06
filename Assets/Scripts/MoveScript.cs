using UnityEngine;

public class MoveScript : MonoBehaviour {

    public float speed = 0.5f;
    
    void FixedUpdate() {
        transform.position += Vector3.up * speed;
    }
}