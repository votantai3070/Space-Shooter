using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 2f;
    private GameManager bulletPool;
    private EnemyManage enemyPool;
    private SpawnEnemy spawnEnemy;

    [System.Obsolete]
    private void Awake()
    {
        spawnEnemy = FindObjectOfType<SpawnEnemy>();
    }

    private void OnEnable()
    {
        Invoke("Deactivate", lifeTime);
    }

    private void OnDisable()
    {
        CancelInvoke("Deactivate");
    }

    public void SetPool(GameManager pool, EnemyManage poolEnemy)
    {
        if (pool != null)
        {
            bulletPool = pool;
        }
        else if (poolEnemy != null)
        {
            enemyPool = poolEnemy;
        }
        else
        {
            Debug.LogError("Bullet pool is not set!");
        }

    }

    private void Deactivate()
    {
        if (bulletPool != null)
        {
            bulletPool.ReturnBulletToPool(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Bullet hit enemy: " + collision.name);

            spawnEnemy.EnemyDied();

            Destroy(collision.gameObject);
            Deactivate();
        }
        else if (collision.CompareTag("Player"))
        {
            Debug.Log("Bullet hit player: " + collision.name);
            Destroy(collision.gameObject);
            Deactivate();
        }
    }


}
