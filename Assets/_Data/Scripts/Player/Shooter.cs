using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Transform centralGun;
    public float bulletSpeed = 10f;
    public float fireRate = 0.5f;
    void Start()
    {
        InvokeRepeating("Shoot", 0f, fireRate);
    }

    void Shoot()
    {
        GameObject bullet = GameManager.Instance.GetBulletFromPool();
        bullet.transform.position = centralGun.position;
        bullet.transform.rotation = centralGun.rotation;
        bullet.SetActive(true);

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.SetPool(GameManager.Instance, null);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = centralGun.up * bulletSpeed;
    }
}
