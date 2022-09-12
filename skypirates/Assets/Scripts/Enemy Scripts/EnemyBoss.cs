using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    public float health = 200;

    private MainCharacterController mainCharacterController;

    void Start()
    {
        GameObject mainCharacterControllerObject = GameObject.FindWithTag("MainCharacterController");
        if (mainCharacterControllerObject != null)
        {
            mainCharacterController = mainCharacterControllerObject.GetComponent<MainCharacterController>();
        }
    }

    void Update()
    {
        
    }

    public void Damaged()
    {
        health -= 100;

        if (health <= 0)
        {
            Destroy(gameObject);

            if (mainCharacterController != null)
            {
                mainCharacterController.ChangeScore(50);
            }
        }
    }
}
