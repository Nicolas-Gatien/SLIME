using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;
    public float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = 5;
        StartCoroutine(Spawn());
    }


    IEnumerator Spawn()
    {
        Instantiate(enemies[Random.Range(0, enemies.Length)], transform.position, Quaternion.identity);
        yield return new WaitForSeconds(spawnTime);
        spawnTime *= 0.99f;
        StartCoroutine(Spawn());

    }
}
