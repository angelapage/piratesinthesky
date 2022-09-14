using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBird : Enemy
{
    Rigidbody2D rigid;
    float directionTimer;
    float newTime = 3;
    public int direction = 1;
    public float speed = 8;
    
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        directionTimer -= Time.deltaTime;

        if (directionTimer < 0)
        {
            direction = -direction;
            directionTimer = newTime;
        }

        Movement();
    }

    private void Movement()
    {
        Vector2 position = rigid.position;

        position.x = position.x + Time.deltaTime * speed * direction;

        transform.localScale = new Vector3(-direction, 1, 1); // flip the gameobject to face correctly

        rigid.MovePosition(position);
    }


}
