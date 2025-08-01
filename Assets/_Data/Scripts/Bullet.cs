using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 2f;
    private GameManager bulletPool;
    private EnemyManage enemyPool;

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

    public void Deactivate()
    {
        if (bulletPool != null)
        {
            bulletPool.ReturnBulletToPool(gameObject);
        }
        else if (enemyPool != null)
        {
            enemyPool.ReturnBulletToPool(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
