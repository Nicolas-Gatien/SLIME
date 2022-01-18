using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreChanger : MonoBehaviour
{
    public int score;

    void Start()
    {
        StartCoroutine(ChangeScore());
    }

    IEnumerator ChangeScore()
    {
        while (score > 0)
        {
            ScoreManager.score++;
            yield return new WaitForSeconds(0.003f);
            score--;
        }
        Destroy(gameObject);
    }
}
