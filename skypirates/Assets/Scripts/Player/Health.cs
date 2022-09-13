using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{ 
    [SerializeField]
    private int lives, numOfHearts;

    [SerializeField]
    public Image[] hearts;

    [SerializeField]
    public Sprite fullHeart, emptyHeart;

    private Animator animator;

    public GameObject healthBar;

    void Start()
    {   

        animator = healthBar.GetComponent<Animator>();
    }
    void Update()
    {

        if(lives > numOfHearts)
        {
            lives = numOfHearts;
        }
        for(int i = 0; i<hearts.Length; i++)
        {
            if(i < lives)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void ChangeHealth(int amount)
    {
        lives = lives + amount;
        
        animator.SetTrigger("IsDamaged");

        if (lives <= 0)
                {
                    SceneManager.LoadScene(1);
                    MainCharacterController.score = 0;
                }
    }
}
