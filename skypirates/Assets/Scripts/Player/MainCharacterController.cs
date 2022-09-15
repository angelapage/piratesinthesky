using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class MainCharacterController : MonoBehaviour
{
    private Rigidbody2D rd2d;
    float horizontal;
    float vertical;

    public float speed;
    [SerializeField]
    private float bounce;
    public float stagger;
    private bool left;
    
// NOT actual gravity values, just multiplers. 
    private float defaultGravity = 1;
    [SerializeField]
    private float increaseGravity;
    
    AudioSource audioSource;
    public AudioClip pickup;
    public AudioClip bubblepop;


    public Text scoreText;
    public static int score = 0;

    public GameObject HitBox;

    float invincibleTimer;
    float timeInvincible = 2;
    bool isInvincible;
    public bool attacking;

    protected Health health;

    public GameObject levelLoader;

    private LevelLoader _levelLoader;
    
    void Start()
    {
        health = GetComponent<Health>();
        rd2d = GetComponent<Rigidbody2D>();

        _levelLoader = levelLoader.GetComponent<LevelLoader>();
        
        rd2d.gravityScale = defaultGravity;

        audioSource = GetComponent<AudioSource>();

        scoreText.text = "Score: " + score.ToString();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = rd2d.velocity.y;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            HitBox.SetActive(true);

            HitBoxAttack a = GetComponentInChildren<HitBoxAttack>();

            a.Attack();
            attacking = true;

        }

        if (isInvincible == true)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }
        }

        FastFalling();    
    }

    void FixedUpdate()
    {
        rd2d.velocity = new Vector2(horizontal * speed, vertical);       
    }

    public void ProcessCollision(GameObject collision)
    {   
        if (collision.tag == "Ground")
        {
            _levelLoader.LoadNextLevel();
        }            
    }

    private void OnTriggerEnter2D(Collider2D collision)
{
     if (collision.tag == "Pearl")
        {
            PlaySound(pickup);
            score += 100;
            scoreText.text = "Score" + score.ToString();
            Destroy(collision.gameObject);
        }
     
    if (collision.tag == "Enemy")
        {
            if (isInvincible == false)
            {
                if (attacking == false)
                {
                    health.ChangeHealth(-1); 

                    rd2d.velocity = new Vector2(horizontal, vertical + stagger);

                    isInvincible = true;
                    invincibleTimer = timeInvincible;               
                }
            }

            PlaySound(bubblepop);
        }
}

    public void ChangeScore(int scoreAmount)
    {
        score += scoreAmount;
        scoreText.text = "Score: " + score.ToString();
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
    public void endattack()
    {
        attacking = false;
    }
}