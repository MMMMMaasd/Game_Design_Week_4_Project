using UnityEngine;

public class SwitchController : MonoBehaviour {
    public bool m_active = false;
    public Sprite[] m_sprites = new Sprite[2];

    SpriteRenderer m_renderer;
    DoorController m_doorCon;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        m_renderer = gameObject.GetComponent<SpriteRenderer>();
        m_doorCon = GameObject.Find("ExitDoor").GetComponent<DoorController>();
    }

    void OnTriggerEnter2D(Collider2D coll) {
        Vector3 playerDir = Vector3.Normalize((Vector3) coll.attachedRigidbody.linearVelocity);
        if (playerDir == transform.right) {
            Activate();
        }
    }

    void Activate() {
        m_renderer.sprite = m_sprites[1];
        m_active = true;
        m_doorCon.CheckSwitches();
    }

    // DEBUG PURPOSES ONLY
    void OnMouseDown() {
        Activate();
    }
}
