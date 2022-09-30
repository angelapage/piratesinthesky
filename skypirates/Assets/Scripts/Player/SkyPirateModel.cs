using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyPirateModel : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void playAttackAnimation()
    {
        animator.SetTrigger("Attacking");
    }
}
