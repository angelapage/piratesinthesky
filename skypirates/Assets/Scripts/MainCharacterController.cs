using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainCharacterController : MonoBehaviour
{
    private Rigidbody2D rd2d;
    float horizontal;
    float vertical;

    public float speed;
    [SerializeField]
    private float bounce;
    
// NOT actual gravity values, just multiplers. 
    private float defaultGravity = 1;
    [SerializeField]
    private float increaseGravity;
    private int lives = 3;

    AudioSource audioSource;
    public AudioClip pickup;
    public AudioClip bubblepop;

    public Text livesText;
    public Text scoreText;
    public static int score = 0;

    public GameObject HitBox;

    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        rd2d.gravityScale = defaultGravity;

        audioSource = GetComponent<AudioSource>();

        livesText.text = "Lives: " + lives.ToString();
        scoreText.text = "Score: " + score.ToString();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = rd2d.velocity.y;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            HitBox.SetActive(true);

            AttackHitBox a = GetComponentInChildren<AttackHitBox>();

            a.Attack();
        }

        FastFalling();    
    }

    void FixedUpdate()
    {
        //Changed movement code since it conflicted with the bounce mechanic. 

        /*Vector2 position = rd2d.position;
        position.x = position.x + 3.0f * horizontal * Time.deltaTime;

        rd2d.MovePosition(position); */

        rd2d.velocity = new Vector2(horizontal * speed, vertical);       
    }

     private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.tag == "Pearl")
        {
            PlaySound(pickup);
            score += 100;
            scoreText.text = "Score" + score.ToString();
            Destroy(collision.collider.gameObject);
        }

        if (collision.collider.tag == "Ground")
        {
            SceneManager.LoadScene(2);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            lives -= 1;
            livesText.text = "Lives: " + lives.ToString();
            if (lives <= 0)
            {
                SceneManager.LoadScene(2);
            }

            BounceUp();
            PlaySound(bubblepop);

            // score += 50;
            // scoreText.text = "Score" + score.ToString();
        }
    }

    private void FastFalling()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
             vertical = vertical * 2;

            //rd2d.AddForce(-transform.up * bounce, ForceMode2D.Impulse);
            //rd2d.gravityScale = increaseGravity;
            Debug.Log("Increasing Gravity");
        }
       if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            vertical = vertical / 2;
            //rd2d.gravityScale = defaultGravity;
             Debug.Log("Stopped increasing Gravity");
        }
    }

     public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
     
    public void BounceUp()
    {
        rd2d.AddForce(transform.up * bounce, ForceMode2D.Impulse);
    }
}