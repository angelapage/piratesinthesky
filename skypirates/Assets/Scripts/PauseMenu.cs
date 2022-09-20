using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private XboxControls xbox;

    private void Awake()
    {
        xbox = new XboxControls();
    }

    private void OnEnable()
    {
        xbox.Enable();
    }
    private void OnDisable()
    {
        xbox.Disable();
    }
    void Update()
    {
        if(xbox.PlayerMovement.Pause.triggered && !isPaused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;

            AudioListener.pause = true;
        }    
        
        else if(xbox.PlayerMovement.Pause.triggered && isPaused)
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
