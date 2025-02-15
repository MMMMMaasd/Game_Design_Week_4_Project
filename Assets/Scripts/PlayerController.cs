using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed;
    private Rigidbody2D body;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);
    }
}
