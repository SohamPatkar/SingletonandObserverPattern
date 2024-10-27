using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance { get; set; }

    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnInterval = 2.0f;
    [SerializeField] private int enemyCount;
    private int enemyCounter;
    private bool spawningActive = true;
    private int randomSpawnPoint;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        enemyCounter = 0;
        while (enemyCounter != enemyCount)
        {
            Debug.Log(enemyCounter);
            yield return new WaitForSeconds(0.5f);
            spawningActive = true;
            while (spawningActive)
            {
                yield return new WaitForSeconds(spawnInterval);
                randomSpawnPoint = Mathf.RoundToInt(Random.Range(0, spawnPoints.Length));
                if (spawningActive)
                {
                    int enemyIndex = Mathf.RoundToInt(Random.Range(0, 2));
                    Instantiate(enemyPrefab[enemyIndex], spawnPoints[randomSpawnPoint]);
                    enemyCounter++;
                    spawningActive = false;
                }
            }
        }
    }
}
