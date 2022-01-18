using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public GameObject GFX;
    private SpriteRenderer myRenderer;
    private Shader shaderGUItext;
    private Shader shaderSpritesDefault;
    public int health;
    private AudioSource takeDamage;

    public int damage;

    public int score = 10;

    public GameObject changeFormSound;

    void Start()
    {
        if(GFX == null)
        {
            GFX = this.gameObject;
        }
        takeDamage = GetComponent<AudioSource>();
        WaveManager.enemiesAlive++;
        myRenderer = GFX.GetComponent<SpriteRenderer>();
        shaderGUItext = Shader.Find("GUI/Text Shader");
        shaderSpritesDefault = Shader.Find("Sprites/Default"); // or whatever sprite shader is being used

    }
    void Update()
    {
        if (health <= 0)
        {
            PlayerOther.playerTimer += (score / 10);
            WaveManager.enemiesAlive--;
            FindObjectOfType<ScoreManager>().ChangeScore(score);
            while (score > 0)
            {
                Instantiate(SpecialManager.slimeBall, transform.position, Quaternion.identity);
                score -= 15;
            }
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        if (!ButtonEvents.mute)
        {
        takeDamage.Play();

        }
        StartCoroutine(Hurt(damage));
    }

    IEnumerator Hurt(int damage)
    {
        health -= damage;
        whiteSprite();
        yield return new WaitForSeconds(0.1f);
        normalSprite();
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Death"))
        {
            health -= 5;
        }

        if (other.CompareTag("Player"))
        {
            if(FindObjectOfType<SpecialManager>().specialsPickedUp < 22)
            {
                if(SpecialManager.state == SpecialManager.slimeState)
                {
                    if(transform.position.y + 0.1f < other.transform.position.y)
                    {
                        var ai = GetComponent<WalkingEnemyAI>();
                        if(ai == null)
                        {
                            health -= 3;
                            FindObjectOfType<PlayerMovement>().Jump();
                            return;
                        }else
                        {
                            FindObjectOfType<PlayerMovement>().Jump();
                            return;
                        }

                    }
                }else if(SpecialManager.state == SpecialManager.walkingState)
                {
                    if (transform.position.y + 0.7f > other.transform.position.y)
                    {
                        health -= 3;
                        return;

                    }

                }
                
                    if (other != null)
                    {
                        other.GetComponent<PlayerHealth>().TakeDamage(1);

                    }
                    Debug.Log(other.name);
                

                
            }
            else
            {
                SpecialManager.state = GetComponent<BaseAI>().type;
                Instantiate(changeFormSound, transform.position, Quaternion.identity);
                health -= 100;

                FindObjectOfType<SpecialManager>().specialsPickedUp -= FindObjectOfType<SpecialManager>().specialsPickedUp;

            }


        }
    }



}
