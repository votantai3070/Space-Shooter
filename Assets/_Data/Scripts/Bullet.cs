using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 2f;
    private GameManager bulletPool;

    private void OnEnable()
    {
        Invoke("Deactivate", lifeTime);
    }

    private void OnDisable()
    {
        CancelInvoke("Deactivate");
    }

    public void SetPool(GameManager pool)
    {
        bulletPool = pool;
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
}
