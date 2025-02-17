using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string m_firstScene;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void StartGame() {
        ScoreTracker.Reset();
        SceneManager.LoadScene(m_firstScene);
    }
}
