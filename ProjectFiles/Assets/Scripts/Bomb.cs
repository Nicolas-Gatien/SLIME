using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public bool evil;

    public GameObject explodeEffect;
    public GameObject force;

    public Sprite goodSprite;
    public Sprite evilSprite;


    bool wasEvil;
    public bool hasCollectedTarget;

    private void Start()
    {
        StartCoroutine(ExplodeAfterStart());
    }
    private void Update()
    {
        if (evil)
        {
            GetComponent<SpriteRenderer>().sprite = evilSprite;
        }else
        {
            GetComponent<SpriteRenderer>().sprite = goodSprite;

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && evil)
        {
            other.GetComponent<PlayerHealth>().TakeDamage(1);
            Explode();

        }

        if (other.CompareTag("Bullet") && evil)
        {

            Destroy(other.gameObject);

            wasEvil = true;
            evil = false;
            StartCoroutine(Expire());
            return;

        }
        if (other.CompareTag("Bullet") && !evil && !wasEvil)
        {
            Explode();

        }


        if (other.CompareTag("Enemy") && !evil)
        {
            other.GetComponent<EnemyBase>().TakeDamage(5);
            Explode();

        }
        if (other.CompareTag("Target") && !evil)
        {

            if(hasCollectedTarget == false)
            {
                other.GetComponent<Target>().Collect();
                hasCollectedTarget = true;
            }
            Explode();
        }
    }

    IEnumerator Expire()
    {
        yield return new WaitForSeconds(0.1f);
        wasEvil = false;

    }

    IEnumerator ExplodeAfterStart()
    {
        yield return new WaitForSeconds(5f);
        Explode();
    }

    void Explode()
    {

        FindObjectOfType<CameraShake>().ShakeScreen(5);

        Instantiate(explodeEffect, transform.position, Quaternion.identity);
        Instantiate(force, transform.position, Quaternion.identity);
        

        Destroy(gameObject);
    }

    
}
