using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public GameObject[] enemyPrefabs;
    public Transform[] spawnPaths;
    public GameObject bossPrefab;
    public Transform bossPaths;
    public float spawnDelay = 0.3f;
    private int enemyAlive = 0;

    private int currentWave = 0;
    private int maxWaves = 5;
    private bool isSpawning = false;
    private Transform[] bossSpawnPath;

    public SettingsManager settingsManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (currentWave >= maxWaves && enemyAlive <= 0 && !isSpawning)
        {
            HealthBar.instance.ShowHealthBar();
        }
        Invoke("StartSpawning", 2f);
    }

    void Update()
    {
        if (Time.timeScale == 0)
            return;
        if (currentWave >= maxWaves && enemyAlive <= 0 && !isSpawning)
        {
            SpawnBoss();
            enabled = false;
            HealthBar.instance.ShowHealthBar();
        }
    }

    private void StartSpawning()
    {
        StartCoroutine(SpawnWaveCoroutine());
    }

    System.Collections.IEnumerator SpawnWaveCoroutine()
    {
        isSpawning = true;
        currentWave++;
        Transform selectedPath = spawnPaths[Random.Range(0, spawnPaths.Length)];

        for (int i = 0; i < GameSettings.instance.enemySpawn; i++)
        {
            GameObject selectedEnemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

            GameObject enemy = Instantiate(selectedEnemy, selectedPath.GetChild(0).position, Quaternion.identity);

            enemy.GetComponent<EnemyMovement>().SetPath(selectedPath);

            enemy.GetComponent<EnemyMovement>().SetSpawner(this);

            enemyAlive++;

            yield return new WaitForSeconds(spawnDelay);
        }
        isSpawning = false;

        if (enemyAlive <= 0 && currentWave < maxWaves)
            StartCoroutine(SpawnWaveCoroutine());
    }

    public void EnemyDied()
    {
        enemyAlive--;
        Debug.Log("Enemy died. Enemies alive: " + enemyAlive);
        if (enemyAlive <= 0 && !isSpawning && currentWave < maxWaves)
            StartCoroutine(SpawnWaveCoroutine());
    }


    private void SpawnBoss()
    {
        bossSpawnPath = new Transform[bossPaths.childCount];

        for (int i = 0; i < bossPaths.childCount; i++)
        {
            bossSpawnPath[i] = bossPaths.GetChild(i);
        }

        Instantiate(bossPrefab, bossSpawnPath[0].position, Quaternion.identity);
    }

}
