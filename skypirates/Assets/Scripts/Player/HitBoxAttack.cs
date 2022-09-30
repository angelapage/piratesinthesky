using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxAttack : MonoBehaviour
{
    public GameObject Self;
    float activeTimer = 0.4f;

    void Update()
    {
        activeTimer -= Time.deltaTime;
        if (activeTimer <= 0)
        {
            MainCharacterController c = GetComponentInParent<MainCharacterController>();
            c.endattack();
            Self.SetActive(false);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {     
        Enemy e = other.GetComponent<Enemy>();
        HitPoint h = other.GetComponent<HitPoint>();
        MainCharacterController c = GetComponentInParent<MainCharacterController>();

        if (e != null)
        {
            c.BounceUp();
            e.Damaged();     
        }
        
        if (h != null)
        {
            h.DealDamage();
            c.BounceUp();
        }
    }
    public void Attack()
    {
        activeTimer = 0.4f;
    }
}