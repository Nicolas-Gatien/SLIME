using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveManager : MonoBehaviour
{
    public TextMeshProUGUI waveText;
    public static int enemiesAlive;
    int wave;
    bool spawningWave;
    public GameObject portal;
    public Vector2[] portalPoses;

    [SerializeField]
    public List<GameObject> enemies;

    bool failedToSpawn;

    float time;

    public GameObject[] newEnemies;

    private void Start()
    {
        wave = 1;

        enemiesAlive = 0;
        StartCoroutine(SpawnWave());
    }

    private void Update()
    {
        waveText.text = "Wave " + wave;

        if(enemiesAlive == 0 && !spawningWave)
        {
            FindObjectOfType<ScoreManager>().ChangeScore(20 * (int)time);

            time = 0;

        }
    }

    IEnumerator SpawnWave()
    {
        spawningWave = true;

 


        int pos = Random.Range(0, portalPoses.Length);
        GameObject tempPortal = Instantiate(portal, portalPoses[pos], Quaternion.identity);

        yield return new WaitForSeconds(2f);


        int currentWave = wave;
        if (wave == 3)
        {
            enemies.Add(newEnemies[0]);
            enemies.Add(newEnemies[1]);

            currentWave = 2;
            failedToSpawn = true;
        }
        if (wave == 7)
        {
            enemies.Add(newEnemies[0]);
            enemies.Add(newEnemies[1]);
            enemies.Add(newEnemies[2]);

            currentWave = 4;
            failedToSpawn = true;
        }
        if (currentWave == 0)
        {
            currentWave++;
        }

        while(currentWave > 0)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.45f);
            currentWave--;

        }

        while (failedToSpawn == false)
        {
            if(Random.Range(0, 101) < wave)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(0.45f);
            }else
            {
                failedToSpawn = true;
            }
        }
        tempPortal.GetComponent<Animator>().SetTrigger("End");
        Destroy(tempPortal,2);

        failedToSpawn = false;
        spawningWave = false;

        while (time > 0)
        {

            yield return new WaitForSeconds(0.5f);
            time -= 0.5f;
        }

        wave++;
        StartCoroutine(SpawnWave());

        void SpawnEnemy()
        {
            Instantiate(enemies[Random.Range(0, enemies.Count)], portalPoses[pos], Quaternion.identity);
            time += 5;
        }
    }






















    /*  public TextMeshProUGUI waveText;
    public GameObject portal;
    public Wave[] waves;
    public static int enemiesAlive;
    int wave;
    bool spawningWave;

    float time;
    bool firstWave;

    private void Start()
    {
        enemiesAlive = 0;
        time = waves[wave].time;
        firstWave = true;
    }

    // Update is called once per frame
    void Update()
    {
        waveText.text = "Wave " + (wave + 1);
        time -= Time.deltaTime;
        if(time < 0 && !spawningWave)
        {
            wave++;

            spawningWave = true;
            StartCoroutine(SpawnWave());
        }
        if(!spawningWave && enemiesAlive == 0)
        {

            spawningWave = true;
            if (!firstWave)
            {
                FindObjectOfType<ScoreManager>().ChangeScore(20 * (int)time);

                wave++;

            }

            StartCoroutine(SpawnWave());

        }
    }

    IEnumerator SpawnWave()
    {

        GameObject curPortal = Instantiate(portal, waves[wave].portalPos, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < waves[wave].enemies.Length; i++)
        {
            Instantiate(waves[wave].enemies[i], waves[wave].portalPos, Quaternion.identity);
            yield return new WaitForSeconds(0.3f);
        }
        yield return new WaitForSeconds(1f);
        Destroy(curPortal);
        time = waves[wave].time;
        if(firstWave == true)
        {
            firstWave = false;
        }
        spawningWave = false;

    }*/
}
