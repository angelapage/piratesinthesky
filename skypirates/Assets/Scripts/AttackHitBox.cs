using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitBox : MonoBehaviour
{
    public GameObject Self;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    public void OnCollisionEnter2D(Collision2D other)
    {
        Enemy e = other.collider.GetComponent<Enemy>();
        MainCharacterController c = GetComponentInParent<MainCharacterController>();

        if (e != null)
        {
            e.Damaged();
            c.BounceUp();
        }
    }

    public void Attack()
    {
        StartCoroutine("DeactivateHitBox");
    }

    IEnumerator DeactivateHitBox()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Self.SetActive(false);
        }
    }

}
