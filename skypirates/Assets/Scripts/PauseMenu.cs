using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.E)) && !isPaused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;

            AudioListener.pause = true;
        }    
        
        else if((Input.GetKeyDown(KeyCode.E)) && isPaused)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;

            AudioListener.pause = false;
        }
    }

    [SerializeField]
    GameObject pauseMenu;

    private bool isPaused = false;
}
