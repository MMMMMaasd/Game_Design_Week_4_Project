using UnityEngine;

public class SwitchController : MonoBehaviour {
    public bool m_active = false;

    DoorController m_doorCon;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        m_doorCon = GameObject.Find("ExitDoor").GetComponent<DoorController>();
    }

    // Update is called once per frame
    // void Update() {
        
    // }

    void OnTriggerEnter2D(Collider2D coll) {
        Vector3 playerDir = Vector3.Normalize((Vector3) coll.attachedRigidbody.linearVelocity);
        if (playerDir == transform.right) {
            Activate();
        }
    }

    void Activate() {
        m_active = true;
        m_doorCon.CheckSwitches();
    }

    // DEBUG PURPOSES ONLY
    void OnMouseDown() {
        Activate();
    }
}
