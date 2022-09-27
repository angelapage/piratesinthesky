using UnityEngine;
using UnityEngine.UI;   

public class ScoreDisplay : MonoBehaviour
{
    private int score;
    public Text scoreText;


    void Start()
    {
        score = MainCharacterController.score;
        scoreText.text = $"Score: {score}";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
