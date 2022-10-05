using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100;
    public float damage;
    public GameObject splat;
    private MainCharacterController mainCharacterController;
    public GameObject armourhit;
    public GameObject hitEffect;

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
        

        if (health == 50)
        {
            Instantiate(armourhit);
        }
        
        if (health <= 0)
        {
        
            Instantiate(splat, transform.position, transform.rotation);
            
            Destroy(gameObject);
        
        }


    }
}
