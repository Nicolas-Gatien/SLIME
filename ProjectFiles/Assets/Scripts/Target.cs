using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Vector2 maxPos;
    public Vector2 minPos;

    public float checkRadius;
    public LayerMask whatIsGround;
    public Sprite sprite;
    bool isCloseToWall;

    public int score;

    public GameObject target;
    Animator anim;

    public GameObject collectObject;

    public float startTimer;
    float timer;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        GetComponent<CircleCollider2D>().enabled = false;
        timer = startTimer;
        isCloseToWall = true;
        StartCoroutine(Show());
    }


    private void Update()
    {
        isCloseToWall = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsGround);

        if (isCloseToWall)
        {
            transform.position = new Vector2(Random.Range(minPos.x, maxPos.x), Random.Range(minPos.y, maxPos.y));
        }

        timer -= Time.deltaTime;
        if(timer <= 0){
            RunOutOfTime();
        }

    }

    IEnumerator Show()
    {
        yield return new WaitForSeconds(1.25f);
        GetComponent<CircleCollider2D>().enabled = true;
        transform.localScale = new Vector2(1f, 1f);

    }

    public void Collect()
    {

        Vector2 pos = new Vector2(Random.Range(minPos.x, maxPos.x), Random.Range(minPos.y, maxPos.y));
        FindObjectOfType<ScoreManager>().ChangeScore(score * (int)timer);

        Instantiate(collectObject, transform.position, Quaternion.identity);
        Instantiate(target, pos, Quaternion.identity);
        Destroy(gameObject);

    }

    void RunOutOfTime()
    {
        anim.SetTrigger("End");

        timer = startTimer;
        Vector2 pos = new Vector2(Random.Range(minPos.x, maxPos.x), Random.Range(minPos.y, maxPos.y));
        Instantiate(target, pos, Quaternion.identity);
       Destroy(gameObject, 1);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }
}
