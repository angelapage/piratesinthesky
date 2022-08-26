using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainCharacterController : MonoBehaviour
{
    private Rigidbody2D rd2d;
    float horizontal;

    public float speed;
    private int lives = 3;

    public Text livesText;
    public Text scoreText;
    private int score = 0;

    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        livesText.text = "Lives: " + lives.ToString();
        scoreText.text = "Score: " + score.ToString();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

         if (lives <= 0)
        {
            SceneManager.LoadScene(4);
        } 
    }

    void FixedUpdate()
    {
        Vector2 position = rd2d.position;
        position.x = position.x + 3.0f * horizontal * Time.deltaTime;

        rd2d.MovePosition(position);
    }

     private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.tag == "Pearl")
        {
            score += 1;
            scoreText.text = "Score" + score.ToString();
            Destroy(collision.collider.gameObject);
        }

        if (collision.collider.tag == "Ground")
        {
            SceneManager.LoadScene(4);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            Destroy(collision.collider.gameObject);
        }
    }
}