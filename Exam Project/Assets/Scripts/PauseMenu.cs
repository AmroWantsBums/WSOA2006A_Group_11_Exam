using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public PlayerController playercontroller;
    public GameObject pauseMenuUI;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0f)
                ResumeGame();
            else
                PauseGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;

        // Enable the pause menu UI
        pauseMenuUI.SetActive(true);
        playercontroller.enabled = false;
        Cursor.visible = true;
    }

    void ResumeGame()
    {
        // Unfreeze time
        Time.timeScale = 1f;

        // Disable the pause menu UI
        pauseMenuUI.SetActive(false);
        playercontroller.enabled = true;
    }
}
