using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI highscoreText;
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        highscoreText.text = PlayerPrefs.GetInt("highScore").ToString(); 
    }

    public void PlayButton()
    {
        FindObjectOfType<SceneLoader>().LoadLevel(1);
        Pressed();

    }
    public void Exit()
    {
        Application.Quit();
        Pressed();

    }

    void Pressed()
    {
        source.Play();
    }
}
