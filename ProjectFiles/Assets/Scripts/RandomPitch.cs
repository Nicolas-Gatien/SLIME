using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPitch : MonoBehaviour
{
    public AudioSource source;

    public float minPitch;
    public float maxPitch;

    private void Awake()
    {
        if (ButtonEvents.mute)
        {
            source.mute = true;
        }
        source.pitch = Random.Range(minPitch, maxPitch);
    }

    private void Update()
    {
        if (ButtonEvents.mute)
        {
            source.mute = true;
        }else
        {
            source.mute = false;

        }
    }
}
