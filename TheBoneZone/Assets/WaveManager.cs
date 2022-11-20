using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public Text countDowntxt;
    public Transform WaypointsSouth;

    public float time = 20f;
    float countDown = 2f;

    int waveNumber = 0;

    private void Update()
    {
        if (countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = time;
        }
        countDown -= Time.deltaTime;
        countDowntxt.text = Mathf.Round(countDown).ToString();
    }

    IEnumerator SpawnWave()
    {
        waveNumber++;
        for (int i = 0; i < waveNumber; i++)
        {
            yield return new WaitForSeconds(0.75f);
            SpawnEnemy();
        }

        yield return null;
    }

    void SpawnEnemy()
    {
        Transform enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
        enemyMovement.Points = WaypointsSouth;
    }
}
