using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAI : BaseAI
{
    public float dashMove;
    Rigidbody2D rb;

    public float checkLength;
    public Transform checkPos;
    public LayerMask whatIsGround;
    bool canSeeWall;

    public float jumpForce;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(Random.Range(0,2) == 0)
        {
            Flip();
        }
        StartCoroutine(Jump());
    }

    private void Update()
    {
        canSeeWall = Physics2D.OverlapCircle(checkPos.position, checkLength, whatIsGround);
        if (canSeeWall)
        {
            Flip();
        }
    }
    IEnumerator Jump()
    {
        rb.velocity = new Vector2(transform.right.x * dashMove, jumpForce);
        yield return new WaitForSeconds(1f);
        StartCoroutine(Jump());
    }

    void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }

    
}
