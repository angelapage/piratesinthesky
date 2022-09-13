using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{ 
    public Text livesText;

    [SerializeField]
    private int lives;

    void Start()
    {
        livesText.text = "Lives: " + lives;
    }

    public void ChangeHealth(int amount)
    {
        lives = lives + amount;
        livesText.text = "Lives: " + lives;

        if (lives <= 0)
                {
                    SceneManager.LoadScene(1);
                    MainCharacterController.score = 0;
                }
    }
}
