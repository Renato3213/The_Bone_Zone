using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public Transform WaypointsSouth;

    public Image hourglassTop, hourglassBot;
    public RectTransform hourglass;

    float progress;
    float percent;

    int waveNumber = 0;

    private void Awake()
    {
        StartCoroutine(WaveCountdown());
    }

    IEnumerator SpawnWave()
    {
        waveNumber++;
        for (int i = 0; i < waveNumber; i++)
        {
            yield return new WaitForSeconds(0.75f);
            SpawnEnemy();
        }

        StartCoroutine(ResetHourglass());

        yield return null;
    }

    public IEnumerator WaveCountdown()
    {
        progress = 0f;
        percent = 0f;
        hourglass.rotation = Quaternion.Euler(0, 0, 0);
        while (percent < 1)
        {
            progress += Time.deltaTime;
            percent = progress / GameManager.instance.invasionCountdown;

            hourglassTop.fillAmount = Mathf.Lerp(1, 0, percent);
            hourglassBot.fillAmount = Mathf.Lerp(0, 1, percent);

            yield return null;
        }
        Debug.Log("uepa");
        StartCoroutine(SpawnWave());

        yield break;
    }

    public IEnumerator ResetHourglass()
    {
        progress = 0f;
        percent = 0f;
        while (percent < 1)
        {
            progress += Time.deltaTime;
            percent = progress / 0.75f;
            hourglass.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(0, 180, percent));
            yield return null;
        }

        StartCoroutine(WaveCountdown());
        Debug.Log("resetou");

        yield break;
    }
    void SpawnEnemy()
    {
        Transform enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
        enemyMovement.Points = WaypointsSouth;
    }


}
