using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public static int highScore;

    public GameObject scoreChanger;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    private void Start()
    {
        score = 0;
        highScore = PlayerPrefs.GetInt("highScore");
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.P) && Input.GetKey(KeyCode.O)){
            PlayerPrefs.SetInt("highScore", 0);

        }
        scoreText.text = "Score: " + score;
        highScoreText.text = "High Score: " + highScore;
        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", highScore);
        }

    }

    public void ChangeScore(int scoreA)
    {

        GameObject changer = Instantiate(scoreChanger, transform.position, Quaternion.identity);
        changer.GetComponent<ScoreChanger>().score = scoreA;
    }


}
