using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public Transform firePoint;
    public float bulletSpeed = 10f;
    public float fireRate = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("Shoot", Random.Range(0f, 2f), fireRate);
    }

    void Shoot()
    {
        GameObject bullet = EnemyManage.Instance.GetBulletFromPool();
        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = firePoint.rotation;
        bullet.SetActive(true);

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        EnemyManage instance = EnemyManage.Instance;
        bulletScript.SetPool(null, instance);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = -firePoint.up * bulletSpeed;
    }
}
