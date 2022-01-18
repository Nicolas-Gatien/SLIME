using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    public Transform location;


    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.position = new Vector2(transform.position.x,location.position.y);
    }
}
