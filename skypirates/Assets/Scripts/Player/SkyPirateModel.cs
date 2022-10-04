using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyPirateModel : MonoBehaviour
{
    private Animator animator;
    public float invincibleTimer;
    public float timeInvincible = 2;
    public bool isInvincible;

    private Vector3 scaleChange = new Vector3(1.0f, 1.0f, 1.0f);

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isInvincible == true)
        {
            ChangeScale();
            invincibleTimer -= Time.deltaTime;

            if (invincibleTimer <= 0)
            {
                isInvincible = false;
            }
        }
    }

    public void playAttackAnimation()
    {
        animator.SetTrigger("Attacking");
    }

    public void ChangeScale()
    {
        transform.localScale -= scaleChange;

        if (transform.localScale.x <= 40f)
        {
            scaleChange = new Vector3(-1.0f, -1.0f, -1.0f);
        }

        if (transform.localScale.x >= 50f)
        {
            scaleChange = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }
}
