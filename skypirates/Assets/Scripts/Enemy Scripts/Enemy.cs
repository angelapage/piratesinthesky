using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100;
    public float damage;
    public GameObject splat;
    private MainCharacterController mainCharacterController;

    void Start()
    {
    
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
            

            if (mainCharacterController != null)
            {
                mainCharacterController.ChangeScore(50);
            }
             Instantiate(splat);
            Destroy(gameObject);
        }
    }

}
