using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxAttack : MonoBehaviour
{
    public GameObject Self;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Enemy e = other.collider.GetComponent<Enemy>();
        HitPoint h = other.collider.GetComponent<HitPoint>();
        MainCharacterController c = GetComponentInParent<MainCharacterController>();

        if (e != null)
        {
            e.Damaged();
            c.BounceUp();
        }
        if (h != null)
        {
            h.DealDamage();
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
