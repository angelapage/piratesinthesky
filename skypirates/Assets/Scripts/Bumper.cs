using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    private Rigidbody2D rd2d;
    Vector2 lastVelocity;
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        lastVelocity = rd2d.velocity;
    }

    void OnCollisionEnter2D(Collision coll)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector2.Reflect(lastVelocity.normalized, coll.contacts[0].normal);

        rd2d.velocity = direction * Mathf.Max(speed, 5f);
    }
}
