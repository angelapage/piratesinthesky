using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private XboxControls xbox;
    [SerializeField]
    private Button backBtn = null;

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
            backBtn.Select();
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
