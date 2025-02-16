using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float m_speed;
    public int m_lives = 3;

    Animator m_animator;
    Rigidbody2D m_body;
    bool m_grounded = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        m_animator = GetComponent<Animator>();
        m_body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newScale = transform.localScale;
        if (Input.GetKeyDown(KeyCode.W) && m_grounded) {
            Physics2D.gravity = new Vector2(0, 7f);
            newScale.y = -5;
        } else if (Input.GetKeyDown(KeyCode.S) && m_grounded) {
            Physics2D.gravity = new Vector2(0, -7f);
            newScale.y = 5;
        } else if (Input.GetKeyDown(KeyCode.A) && m_grounded) {
            Physics2D.gravity = new Vector2(-7f, 0);
            newScale.x = -5;
        } else if (Input.GetKeyDown(KeyCode.D) && m_grounded) {
            Physics2D.gravity = new Vector2(7f, 0);
            newScale.x = 5;
        }
        transform.localScale = newScale;

        // tell animator whether the player is moving
        m_animator.SetFloat("Speed", Mathf.Abs(m_body.linearVelocity.x));
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            m_grounded = true;
        }

        if (collision.gameObject.CompareTag("Spike")) {
            TakeDamage();
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            m_grounded = false;
        }
    }

    void TakeDamage() {
        m_lives--;
        Debug.Log("Lives left: " + m_lives);

        if (m_lives <= 0) Die();
    }

    void Die() {
        Debug.Log("Player Died!");
        gameObject.SetActive(false);
    }
}
