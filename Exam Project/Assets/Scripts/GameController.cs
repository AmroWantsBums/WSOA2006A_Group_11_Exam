using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public string nextLevelName; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player") 
        {
            UnityEngine.SceneManagement.Scene currentScene = SceneManager.GetActiveScene();
            if (currentScene.name == "Level7")
            {
                Application.Quit();
            }
            else
            {
                LoadNextLevel();
            }
        }
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevelName);
    }
}
