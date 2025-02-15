using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float m_speed;

    Animator m_animator;
    Rigidbody2D m_body;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        m_animator = GetComponent<Animator>();
        m_body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // basic horizontal motion, this may need to be changed when we implement the gravity
        float horizMotion = Input.GetAxisRaw("Horizontal") * m_speed;
        m_body.linearVelocity = new Vector2(horizMotion, m_body.linearVelocity.y);

        // flip body horizontally depending on motion direction
        if (horizMotion < 0) {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        } else if (horizMotion > 0) {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        // tell animator whether the player is moving
        m_animator.SetFloat("Speed", Mathf.Abs(horizMotion));
    }
}
