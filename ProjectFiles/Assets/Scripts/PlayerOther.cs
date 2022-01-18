using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerOther : MonoBehaviour
{
    public static int playerTimer;
    public TextMeshProUGUI timerText;
    public int timer = 20;

    private void Start()
    {
        StartCoroutine(ChangeTimer());

        playerTimer = timer;
    }
    private void Update()
    {

        if(playerTimer > 20)
        {
            playerTimer = 20;
        }

        timerText.text = playerTimer.ToString();
        
        if(playerTimer < 0)
        {
            if(SpecialManager.state == SpecialManager.playerState)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            }else
            {
                playerTimer = 20;

                SpecialManager.state = SpecialManager.playerState;
                 
            }
        }
    }

    IEnumerator ChangeTimer()
    {
        yield return new WaitForSeconds(1f);
        playerTimer--;
        StartCoroutine(ChangeTimer());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Target"))
        {
            other.GetComponent<Target>().Collect();
        }
    }
}
