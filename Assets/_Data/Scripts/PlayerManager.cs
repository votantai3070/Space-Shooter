using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    public GameObject bulletPrefab;
    [SerializeField] int initialBulletCount = 5;

    [SerializeField] private List<GameObject> bulletPool = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

    }
    private void Start()
    {
        for (int i = 0; i <= initialBulletCount; i++)
        {
            GameObject gameObject = Instantiate(bulletPrefab);
            gameObject.SetActive(false);
            bulletPool.Add(gameObject);
        }
    }

    public GameObject GetBulletFromPool()
    {
        foreach (GameObject bullet in bulletPool)
        {
            if (!bullet.activeInHierarchy)
            {
                return bullet;
            }
        }

        GameObject newBullet = Instantiate(bulletPrefab);
        newBullet.SetActive(false);
        bulletPool.Add(newBullet);
        return newBullet;
    }

    public void ReturnBulletToPool(GameObject bullet)
    {
        bullet.SetActive(false);
    }
}
