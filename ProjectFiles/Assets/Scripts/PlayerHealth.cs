using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private SpriteRenderer myRenderer;
    private Shader shaderGUItext;
    private Shader shaderSpritesDefault;
    public int health;

    public GameObject deathEffect;
    bool hasDied;




    void Start()
    {
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
        shaderGUItext = Shader.Find("GUI/Text Shader");
        shaderSpritesDefault = Shader.Find("Sprites/Default"); // or whatever sprite shader is being used

    }
    void Update()
    {
        if (health <= 0)
        {
            if(SpecialManager.state == SpecialManager.playerState)
            {
                if (!hasDied)
                {
                    hasDied = true;
                    StartCoroutine(PlayerDeath());

                }
                //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            }
            else
            {
                health = 1;
                SpecialManager.state = SpecialManager.playerState;
            }
        }
        UpdateHealthBar();
    }

    public Image healthBar;
    public Sprite[] sprites;
    bool beingHurt;
    public Sprite damageSprite;

    void UpdateHealthBar()
    {
        if (!beingHurt)
        {
            healthBar.sprite = sprites[health];
        }else
        {
            healthBar.sprite = damageSprite;

        }
    }

    public void TakeDamage(int damage)
    {
        if(health > 0)
        {
            if (!ButtonEvents.mute)
            {
            GetComponent<AudioSource>().Play();

            }
            FindObjectOfType<CameraShake>().ShakeScreen(5);

            StartCoroutine(Hurt(damage));
        }

    }

    IEnumerator PlayerDeath()
    {
        Vector2 pos = new Vector2(transform.position.x, transform.position.y + 0.5f);
        Instantiate(deathEffect, pos, Quaternion.identity);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerWeapon>().enabled = false;



        yield return new WaitForSeconds(0.5f);
        FindObjectOfType<SceneLoader>().LoadLevel(0);

    }
    public void KillPlayer()
    {
        StartCoroutine(MenuDeath());
    }
    IEnumerator MenuDeath()
    {
        Vector2 pos = new Vector2(transform.position.x, transform.position.y + 0.5f);
        Instantiate(deathEffect, pos, Quaternion.identity);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerWeapon>().enabled = false;



        yield return new WaitForSeconds(0.5f);
        FindObjectOfType<SceneLoader>().LoadLevel(-1);

    }



    IEnumerator Hurt(int damage)
    {
        beingHurt = true;
        health -= damage;
        whiteSprite();
        yield return new WaitForSeconds(0.1f);
        normalSprite();
        beingHurt = false;

    }

    void whiteSprite()
    {
        myRenderer.material.shader = shaderGUItext;
        myRenderer.color = Color.white;
    }

    void normalSprite()
    {
        myRenderer.material.shader = shaderSpritesDefault;
        myRenderer.color = Color.white;
    }

}
