using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slimeball : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer spriteRend;
    Animator anim;

    private Shader shaderGUItext;
    private Shader shaderSpritesDefault;

    public Vector2 maxVelocity;
    public Vector2 minVelocity;

    public Sprite flying;
    public Sprite grounded;

    bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public LayerMask afterPickup;

    bool picking;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();
        shaderGUItext = Shader.Find("GUI/Text Shader");
        shaderSpritesDefault = Shader.Find("Sprites/Default"); // or whatever sprite shader is being used
    }

    private void Start()
    {
        Vector2 yeetForce = new Vector2(Random.Range(minVelocity.x, maxVelocity.x), Random.Range(minVelocity.y, maxVelocity.y));
        rb.velocity = yeetForce;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (isGrounded)
        {
            if (!picking)
            {
                spriteRend.sprite = grounded;
            }
            else
            {
                spriteRend.sprite = flying;
            }
        }
        else
        {
            spriteRend.sprite = flying;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && FindObjectOfType<SpecialManager>().specialsPickedUp < 22)
        {
            anim.SetTrigger("PickUp");
            StartCoroutine(PickUp());
        }
    }

    IEnumerator PickUp()
    {

        picking = true;
        spriteRend.sprite = flying;

        whiteSprite();
        gameObject.layer = afterPickup;
        yield return new WaitForSeconds(0.16f);
        normalSprite();
        FindObjectOfType<SpecialManager>().PickedUp();
        Destroy(gameObject);
    }

    void whiteSprite()
    {
        spriteRend.material.shader = shaderGUItext;
        spriteRend.color = Color.white;
    }

    void normalSprite()
    {
        spriteRend.material.shader = shaderSpritesDefault;
        spriteRend.color = Color.white;
    }

}
