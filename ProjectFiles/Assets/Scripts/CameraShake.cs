using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ShakeScreen(int power)
    {
        if(power == 1)
        {
            anim.SetTrigger("Shoot");
        }else if(power > 1)
        {
            anim.SetTrigger("TakeDamage");

        }
    }
}
