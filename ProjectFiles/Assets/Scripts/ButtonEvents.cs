using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEvents : MonoBehaviour
{
    public static bool mute;

    public Sprite muted;
    public Sprite notMuted;
    public Image muteButtonImage;

    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mute)
        {
            muteButtonImage.sprite = muted;
        }else
        {
            muteButtonImage.sprite = notMuted;

        }
    }
    public void MuteButton()
    {
        mute = !mute;
        GetComponent<Button>().interactable = false;
        GetComponent<Button>().interactable = true;
        Pressed();



    }

    public void Menu()
    {
        FindObjectOfType<PlayerHealth>().KillPlayer();
        Pressed();
    }

    void Pressed()
    {
        if (!mute)
        {
            source.Play();

        }
    }
}
