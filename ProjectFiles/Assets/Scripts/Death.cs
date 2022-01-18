using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (SpecialManager.state == SpecialManager.slimeState)
            {

                FindObjectOfType<PlayerMovement>().Jump();
                other.GetComponent<EnemyBase>().TakeDamage(3);

            }
        }
    }
}
