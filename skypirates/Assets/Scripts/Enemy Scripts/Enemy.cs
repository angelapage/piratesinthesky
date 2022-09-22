using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float health = 100;
    public float damage;

    AudioSource audioSource;
    public AudioClip splat;

    private MainCharacterController mainCharacterController;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GameObject mainCharacterControllerObject = GameObject.FindWithTag("MainCharacterController");
        if (mainCharacterControllerObject != null)
        {
            mainCharacterController = mainCharacterControllerObject.GetComponent<MainCharacterController>();
        }
    }

    public void Damaged()
    {
        health -= damage;

        if (health <= 0)
        {
            PlaySound(splat);
            Destroy(gameObject,.15f);

            if (mainCharacterController != null)
            {
                mainCharacterController.ChangeScore(50);
            }
        }
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
