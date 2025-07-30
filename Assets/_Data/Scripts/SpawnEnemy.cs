using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public GameObject[] enemyPrefabs;
    public Transform[] spawnPaths;
    public int spawnPerWave = 5;
    public float spawnDelay = 0.3f;
    private int enemyAlive = 0;

    private int currentWave = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnWaveCoroutine());
    }

    System.Collections.IEnumerator SpawnWaveCoroutine()
    {
        currentWave++;
        Transform selectedPath = spawnPaths[Random.Range(0, spawnPaths.Length)];

        for (int i = 0; i < spawnPerWave; i++)
        {


            GameObject selectedEnemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

            GameObject enemy = Instantiate(selectedEnemy, selectedPath.GetChild(0).position, Quaternion.identity);

            enemy.GetComponent<EnemyMovement>().SetPath(selectedPath);

            enemy.GetComponent<EnemyMovement>().SetSpawner(this);
            enemyAlive++;

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    public void EnemyDied()
    {
        enemyAlive--;
        if (enemyAlive <= 0)
        {
            StartCoroutine(SpawnWaveCoroutine());
        }
    }

}
