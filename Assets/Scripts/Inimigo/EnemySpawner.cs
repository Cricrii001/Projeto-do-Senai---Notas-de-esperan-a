using System.Collections;
using UnityEngine;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints;

    public TMP_Text roundText;

    private int currentRound = 0;

    public static int enemiesAlive = 0;

    void Awake()
    {
        // 🔥 RESET TOTAL ao entrar na cena
        enemiesAlive = 0;
        currentRound = 0;

        if (roundText != null)
            roundText.text = "";
    }

    void Start()
    {
        StopAllCoroutines();
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            // espera limpar a wave
            while (enemiesAlive > 0)
                yield return null;

            yield return new WaitForSeconds(2f);

            currentRound++;

            if (roundText != null)
                roundText.text = "ROUND " + currentRound;

            int quantidade = Random.Range(4, 7);

            Debug.Log($"ROUND {currentRound} - Enemies: {quantidade}");

            for (int i = 0; i < quantidade; i++)
            {
                Transform spawn = spawnPoints[Random.Range(0, spawnPoints.Length)];
                GameObject enemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

                Instantiate(enemy, spawn.position, Quaternion.identity);

                enemiesAlive++;

                yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
            }
        }
    }
}