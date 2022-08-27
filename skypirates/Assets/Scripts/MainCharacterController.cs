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
    [SerializeField]
    private float bounce;
    
// NOT actual gravity values, just multiplers. 
    private float defaultGravity = 1;
    [SerializeField]
    private float increaseGravity;
    private int lives = 3;

    public Text livesText;
    public Text scoreText;
    private int score = 0;

    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        rd2d.gravityScale = defaultGravity;

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

        FastFalling();
    }

    void FixedUpdate()
    {
        //Changed movement code since it conflicted with the bounce mechanic. 

        /*Vector2 position = rd2d.position;
        position.x = position.x + 3.0f * horizontal * Time.deltaTime;

        rd2d.MovePosition(position); */

        rd2d.velocity = new Vector2(horizontal * speed, rd2d.velocity.y);
        //FastFalling();
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
            rd2d.AddForce(transform.up * bounce, ForceMode2D.Impulse);
            Destroy(collision.collider.gameObject);
        }
    }

    private void FastFalling()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            rd2d.gravityScale = increaseGravity;
            Debug.Log("Increasing Gravity");
        }
        if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            rd2d.gravityScale = defaultGravity;
             Debug.Log("Stopped increasing Gravity");
        }
    }
}