using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Profile : MonoBehaviour
{
    Image image;
    public Sprite[] profiles;
    private void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SpecialManager.state == SpecialManager.playerState)
        {
            image.sprite = profiles[0];
        }
        else if (SpecialManager.state == SpecialManager.slimeState)
        {
            image.sprite = profiles[1];

        }
        else if (SpecialManager.state == SpecialManager.flyingState)
        {
            image.sprite = profiles[2];

        }
        else if (SpecialManager.state == SpecialManager.walkingState)
        {
            image.sprite = profiles[3];

        }
    }
}
