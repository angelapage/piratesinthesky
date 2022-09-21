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
    [SerializeField]
    private float maxVelocity = 20;
    Vector2 lastVelocity;
    ContactPoint2D objContact;
    
    AudioSource audioSource;
    public AudioClip pickup;
    public AudioClip bubblepop;


    public Text scoreText;
    public static int score = 0;

    public GameObject HitBox;

    float invincibleTimer;
    float timeInvincible = 1;
    bool isInvincible;

    float disableInput;
    float timeDisabled = 0.5f;
    bool isDisabled;

    public bool attacking;

    protected Health health;

    public GameObject levelLoader;

    private LevelLoader _levelLoader;
    bool boing;

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
        //horizontal = Input.GetAxis("Horizontal");
       //vertical = rd2d.velocity.y;
        lastVelocity = rd2d.velocity;

        if(xbox.PlayerMovement.Attack.triggered)
        {
            PlayerAttack();
        }

        if (isInvincible == true)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer <= 0)
            {
                isInvincible = false;
            }
        }

        if (isDisabled == true)
        {
            timeDisabled -= Time.deltaTime;
            if (timeDisabled <= 0)
            {
                isDisabled = false;
            }
        }

        FastFalling();

    }

    void FixedUpdate()
    {
        if (boing == false)
        {
            if (isDisabled == false)
            {   
                Vector2 move = xbox.PlayerMovement.Move.ReadValue<Vector2>();
                rd2d.velocity = new Vector2(move.x * speed, rd2d.velocity.y);
            }
        
        rd2d.velocity = Vector2.ClampMagnitude(rd2d.velocity, maxVelocity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ProcessCollision(collision.gameObject);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ProcessCollision(collision.gameObject); 
    }

    public void ProcessCollision(GameObject collision)
    {
        if (collision.tag == "Bumper")
        {
            isDisabled = true;
        }

        if (collision.tag == "Ground")
        {
            _levelLoader.LoadNextLevel();
        }

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
        
        if(xbox.PlayerMovement.FastFall.triggered)
        {
             vertical = vertical * 2;

            //rd2d.AddForce(-transform.up * bounce, ForceMode2D.Impulse);
            //rd2d.gravityScale = increaseGravity;
            Debug.Log("Increasing Gravity");
        }

        if(!xbox.PlayerMovement.FastFall.triggered)
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
        boing = true;
        Debug.Log("smack");
        rd2d.velocity = new Vector2(0, 0); 
        rd2d.AddForce(transform.up * bounce, ForceMode2D.Impulse);
        boing = false;
    }

    public void endattack()
    {
        attacking = false;
    }

    void PlayerAttack()
    {
        HitBox.SetActive(true);
        HitBoxAttack a = GetComponentInChildren<HitBoxAttack>();
        a.Attack();
        attacking = true;
    }
}