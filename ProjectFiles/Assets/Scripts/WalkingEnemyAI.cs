using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemyAI : BaseAI
{

    public float dashMove;
    Rigidbody2D rb;

    public float checkLength;
    public Transform checkPos;
    public LayerMask whatIsGround;
    bool canSeeWall;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (Random.Range(0, 2) == 0)
        {
            Flip();
        }
    }

    private void Update()
    {
        canSeeWall = Physics2D.OverlapCircle(checkPos.position, checkLength, whatIsGround);
        if (canSeeWall)
        {
            Flip();
        }
        rb.velocity = new Vector2(transform.right.x * dashMove, rb.velocity.y);

    }


    void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.CompareTag("Player"))
        {

            if(other.transform.position.y> this.transform.position.y + 0.5f)
            {
                other.GetComponent<PlayerHealth>().TakeDamage(1);
                other.GetComponent<PlayerMovement>().Jump();
           }

        }
    }
}
