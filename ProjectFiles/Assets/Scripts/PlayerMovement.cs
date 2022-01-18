using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Movement")]
    Rigidbody2D rb;
    public float speed;
    float movement;

    [Header("Jumping")]
    public float jumpForce;
    bool isGrounded;
    public float checkRadius;
    public LayerMask whatIsGround;
    public Transform checkPos;

    public int extraJumpValue;
    int extraJumps;

    [Header("Polish")]
    public float rememberCoyoteTime;
    float coyoteTime;
    public float rememberJumpTime;
    float jumpTime;
    Animator anim;


    bool facingRight = true;

    public GameObject slimeJumpSound;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        extraJumps = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        coyoteTime -= Time.deltaTime;
        jumpTime -= Time.deltaTime;

        UpdateStates();
        UpdateInput();
        UpdateJump();
        UpdateFacing();
    }

    void UpdateFacing()
    {
        if (facingRight && movement < -0.01f)
        {
            Flip();
        }
        else if (!facingRight && movement > 0.01f)
        {
            Flip();

        }
    }

    void UpdateJump()
    {
        isGrounded = Physics2D.OverlapCircle(checkPos.position, checkRadius, whatIsGround);




        if (isGrounded)
        {
            coyoteTime = rememberCoyoteTime;
            extraJumps = extraJumpValue;
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            jumpTime = rememberJumpTime;
        }

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && extraJumps > 0)
        {
            Jump();
            if (coyoteTime < 0)
            {
                extraJumps--;

            }
        } else if (jumpTime > 0 && extraJumps == 0 && coyoteTime > 0)
        {
            Jump();

        }
    }

    public void Jump()
    {
        if(SpecialManager.state == SpecialManager.slimeState)
        {
            Instantiate(slimeJumpSound, transform.position, Quaternion.identity);
        }
        anim.SetTrigger("Jump");
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);

    }

    void UpdateInput()
    {
        movement = Input.GetAxis("Horizontal");

      
    }
    void UpdateStates()
    {
        speed = SpecialManager.stateStats.moveSpeed;
        jumpForce = SpecialManager.stateStats.jumpForce;
        extraJumpValue = SpecialManager.stateStats.extraJumps;
        anim.runtimeAnimatorController = SpecialManager.stateStats.anim;
        rb.gravityScale = SpecialManager.stateStats.gravityScale;
    }
    private void FixedUpdate()
    {
        if(rb.velocity.sqrMagnitude > 0.01)
        {
            anim.SetBool("IsMoving", true);
        }else
        {
            anim.SetBool("IsMoving", false);

        }

        if(SpecialManager.state == SpecialManager.playerState || SpecialManager.state == SpecialManager.slimeState || SpecialManager.state == SpecialManager.walkingState)
        {
            rb.velocity = new Vector2(movement * speed, rb.velocity.y);


        }else
        {
            Vector2 flyingMovemet = new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * jumpForce);
            rb.velocity = flyingMovemet;


        }
    }

    void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
        facingRight = !facingRight;
    }
}
