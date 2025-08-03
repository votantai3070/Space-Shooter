using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Transform centralGun;
    public Transform effect;
    public float bulletSpeed = 10f;
    public float fireRate = 0.5f;
    public Transform muzzleFalshPrefab;


    void Start()
    {
        InvokeRepeating("Shoot", 0f, fireRate);
    }

    void Shoot()
    {
        GameObject bullet = PlayerManager.Instance.GetBulletFromPool();
        bullet.transform.position = centralGun.position;
        bullet.transform.rotation = centralGun.rotation;

        Effect();
        bullet.SetActive(true);


        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.SetPool(PlayerManager.Instance, null);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = centralGun.up * bulletSpeed;
    }

    void Effect()
    {
        Transform clone = (Transform)Instantiate(muzzleFalshPrefab, effect.position, effect.rotation) as Transform;
        clone.parent = effect;
        float size = Random.Range(0.6f, 0.9f);
        clone.localScale = new Vector3(size, size, size);
        Destroy(clone.gameObject, 0.02f);
    }
}
