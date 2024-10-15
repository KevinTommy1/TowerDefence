using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private int enemiesPerSpawn;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private Enemy[] enemies;
    [SerializeField] private int totalWaves = 10;
    [SerializeField] private Text totalEscapedLabel;
    private GameStateHandler gameStateHandler;
    
    public List<Enemy> EnemyList = new List<Enemy>();
    private int enemiesToSpawn = 0;
    
    const float SpawnDelay = 2f; //Spawn Delay in seconds
    private int waveNumber = 0;
    public int TotalEnemies { get; private set; } = 3;
    public int TotalWaves => totalWaves;

    public int WaveNumber
    {
        get => waveNumber;
        set => waveNumber = value;
    }

    public int TotalKilled { get; private set; } = 0;

    public int TotalEscaped { get; private set; } = 0;

    public int RoundEscaped { get; private set; } = 0;


    IEnumerator Spawn()
    {
        if (enemiesPerSpawn > 0 && EnemyList.Count < TotalEnemies)
        {
            for (int i = 0; i < enemiesPerSpawn; i++)
            {
                if (EnemyList.Count < TotalEnemies)
                {
                    Enemy newEnemy = Instantiate(enemies[Random.Range(0, enemiesToSpawn)]);
                    newEnemy.transform.position = spawnPoint.transform.position;
                    EnemyList.Add(newEnemy);
                }
            }
            yield return new WaitForSeconds(SpawnDelay);
            StartCoroutine(Spawn());
        }
    }

    public void IsWaveOver()
    {
        totalEscapedLabel.text = "Escaped " + TotalEscaped + "/10";
        if (RoundEscaped + TotalKilled == TotalEnemies)
        {
            if (waveNumber <= enemies.Length)
            {
                enemiesToSpawn = waveNumber;
            }
            gameStateHandler.setCurrentGameState();
        }
    }
}