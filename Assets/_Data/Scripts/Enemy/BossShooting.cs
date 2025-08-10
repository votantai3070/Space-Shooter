using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    //public GameObject lazerPrefab;

    public float fireSpeed = 5f;
    //private bool isAttack = false;
    [SerializeField] private int shootStrangthCount = 10;
    [SerializeField] private float shootStrangthDelay = 0.2f;
    [SerializeField] private float shootSpreadCount = 8;
    [SerializeField] private float shootSpreadDelay = 0.5f;

    [SerializeField] private List<GameObject> bulletPool = new List<GameObject>();
    [SerializeField] private int bulletInPool = 10;

    void Start()
    {
        for (int i = 0; i < bulletInPool; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
        StartCoroutine(DelayCoroutine());
    }


    IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(4f);
        StartCoroutine(AttackPattern());
    }

    IEnumerator AttackPattern()
    {
        while (true)
        {
            int randomAttack = Random.Range(0, 2);
            switch (randomAttack)
            {
                case 0:
                    yield return StartCoroutine(NormalAttack());
                    break;
                case 1:
                    yield return StartCoroutine(SpiralAttack());
                    break;
                    //case 2:
                    //    yield return StartCoroutine(LazerAttack());
                    //    break;
            }
            yield return new WaitForSeconds(5f);

        }

    }

    IEnumerator NormalAttack()
    {
        for (int i = 0; i < shootStrangthCount; i++)
        {
            SpawnBullet(-firePoint.up);
            yield return new WaitForSeconds(shootStrangthDelay);
        }
    }

    IEnumerator SpiralAttack()
    {
        float spreadAngle = 60f;
        for (int i = 0; i < shootStrangthCount; i++)
        {
            float angle = -spreadAngle / 2 + (spreadAngle / (shootSpreadCount - 1)) * i;
            Debug.Log("Angle: " + angle);
            Vector2 dir = Quaternion.Euler(0, 0, angle) * -firePoint.up;
            SpawnBullet(dir);
        }
        yield return new WaitForSeconds(shootSpreadDelay);
    }

    //IEnumerator LazerAttack()
    //{
    //    //Effects lazer: ....
    //    yield return new WaitForSeconds(2f);

    //    GameObject lazer = Instantiate(lazerPrefab, firePoint.position, firePoint.rotation);
    //    Destroy(lazer, 2f);
    //}
    private void SpawnBullet(Vector2 dir)
    {
        GameObject bullet = GetBulletInPool();
        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = firePoint.rotation;

        bullet.SetActive(true);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = dir * fireSpeed;

        StartCoroutine(DisableBulletAfterTime(bullet, 6f));
    }

    private GameObject GetBulletInPool()
    {
        foreach (GameObject b in bulletPool)
        {
            if (!b.activeInHierarchy)
            {
                return b;
            }
        }

        GameObject bullet = Instantiate(bulletPrefab);
        bullet.SetActive(false);
        bulletPool.Add(bullet);
        return bullet;
    }

    private IEnumerator DisableBulletAfterTime(GameObject bullet, float time)
    {
        yield return new WaitForSeconds(time);
        if (bullet != null)
        {
            bullet.SetActive(false);
        }
    }
}
