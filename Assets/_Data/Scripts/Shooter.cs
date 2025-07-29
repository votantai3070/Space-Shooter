using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameManager bulletPool;
    public Transform centralGun;
    public float bulletSpeed = 10f;
    public float fireRate = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("Shoot", 0f, fireRate);
    }

    void Shoot()
    {
        GameObject bullet = bulletPool.GetBulletFromPool();
        bullet.transform.position = centralGun.position;
        bullet.transform.rotation = centralGun.rotation;
        bullet.SetActive(true);

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.SetPool(bulletPool);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = centralGun.up * bulletSpeed;
    }
}
