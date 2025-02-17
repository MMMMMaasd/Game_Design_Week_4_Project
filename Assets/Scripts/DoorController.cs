using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour {
    public string m_nextScene;
    public bool m_open = false;

    SwitchController[] m_switchCons;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        GameObject[] switches = GameObject.FindGameObjectsWithTag("Switch");
        m_switchCons = new SwitchController[switches.Length];
        for (int i = 0; i < switches.Length; i++) {
            m_switchCons[i] = switches[i].GetComponent<SwitchController>();
        }
    }

    // when colliding with the player, move to the next level if the door is open
    void OnTriggerEnter2D(Collider2D coll) {
        if (m_open) {
            Debug.Log("Level complete!");
            ScoreTracker.timer += Time.timeSinceLevelLoad;
            SceneManager.LoadScene(m_nextScene);
        }
    }

    // open the door if all the switches are active; called whenever a switch is flipped
    public void CheckSwitches() {
        foreach (SwitchController switchCon in m_switchCons) {
            if (switchCon.m_active == false) return;
        }
        m_open = true;
    }
}
