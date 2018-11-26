using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public Transform SpawnPoint;
    public Transform Unit;

    public int maxpop;
    public float countdown = 5;
    public float cooldown = 5;

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0f)
        {
            //Debug.Log(Enemy.population);
            if (maxpop >= Enemy.population)
            {
                return;
            }

            //Debug.Log(maxpop);
            maxpop++;
            StartCoroutine(SpawnWave());
            countdown = cooldown;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        //Debug.Log("Wave Incomming!");
        SpawnEnemy();
        yield return new WaitForSeconds(0.5f);
    }

    void SpawnEnemy()
    {
        Instantiate(Unit, SpawnPoint.position, SpawnPoint.rotation);
    }
}
