using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingAI : BaseAI
{

    public GameObject bomb;
    private void Start()
    {
        StartCoroutine(SpawnBomb());
    }

    IEnumerator SpawnBomb()
    {
        yield return new WaitForSeconds(10f);
        Instantiate(bomb, transform.position, Quaternion.identity);
        StartCoroutine(SpawnBomb());

    }
}
