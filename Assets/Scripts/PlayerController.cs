using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public float m_speed;
    public int m_lives = 3;

    Animator m_animator;
    Rigidbody2D m_body;
    List<GameObject> m_collisions = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        m_animator = GetComponent<Animator>();
        m_body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        // handle gravity changes and sprite flipping
        bool grounded = m_collisions.Count > 0;
        Vector3 newScale = transform.localScale;
        if (Input.GetKeyDown(KeyCode.W) && grounded) {
            Physics2D.gravity = new Vector2(0, 7f);
            m_body.linearVelocityX = 0;
            newScale.y = -5;
        } else if (Input.GetKeyDown(KeyCode.S) && grounded) {
            Physics2D.gravity = new Vector2(0, -7f);
            m_body.linearVelocityX = 0;
            newScale.y = 5;
        } else if (Input.GetKeyDown(KeyCode.A) && grounded) {
            Physics2D.gravity = new Vector2(-7f, 0);
            m_body.linearVelocityY = 0;
            newScale.x = -5;
        } else if (Input.GetKeyDown(KeyCode.D) && grounded) {
            Physics2D.gravity = new Vector2(7f, 0);
            m_body.linearVelocityY = 0;
            newScale.x = 5;
        }
        transform.localScale = newScale;

        // tell animator whether the player is moving horizontally
        m_animator.SetFloat("Speed", Mathf.Abs(m_body.linearVelocityX));
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            m_collisions.Add(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Spike")) {
            TakeDamage();
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            m_collisions.Remove(collision.gameObject);
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
