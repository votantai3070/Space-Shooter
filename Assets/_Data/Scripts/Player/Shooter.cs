using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;


public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject centralGun;
    [SerializeField] private GameObject leftGun;
    [SerializeField] private GameObject rightGun;
    //public Transform effect;
    public float bulletSpeed = 10f;
    public float fireRate = 0.5f;
    //public Transform muzzleFalshPrefab;
    private ParticleSystem muzzleFlashCentralGun;
    private ParticleSystem muzzleFlashLeftGun;
    private ParticleSystem muzzleFlashRightGun;

    [HideInInspector] public int lvlUpGun = 1;
    [HideInInspector] public int maxLvlUpGun = 4;
    public static Shooter instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        muzzleFlashCentralGun = centralGun.GetComponentInChildren<ParticleSystem>();
        muzzleFlashLeftGun = leftGun.GetComponentInChildren<ParticleSystem>();
        muzzleFlashRightGun = rightGun.GetComponentInChildren<ParticleSystem>();

        InvokeRepeating("Shoot", 0f, fireRate);
    }

    void Shoot()
    {
        switch (lvlUpGun)
        {
            case 1:
                ShootBullet(centralGun, Vector2.right, muzzleFlashCentralGun);
                break;
            case 2:
                ShootBullet(leftGun, Vector2.right, muzzleFlashLeftGun);
                ShootBullet(rightGun, Vector2.right, muzzleFlashRightGun);
                break;
            case 3:
                ShootBullet(centralGun, Vector2.right, muzzleFlashCentralGun);
                ShootBullet(leftGun, Quaternion.Euler(0, 0, 10) * Vector2.right, muzzleFlashLeftGun);
                ShootBullet(rightGun, Quaternion.Euler(0, 0, -10) * Vector2.right, muzzleFlashRightGun);
                break;
        }
    }

    void ShootBullet(GameObject gun, Vector2 direct, ParticleSystem particle)
    {
        GameObject bullet = PlayerManager.Instance.GetBulletFromPool();
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        bullet.transform.position = gun.transform.position;

        float angle = Mathf.Atan2(direct.y, direct.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(0, 0, angle);

        bullet.transform.rotation = gun.transform.rotation;

        //Effect();
        particle.Play();
        bullet.SetActive(true);

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.SetPool(PlayerManager.Instance, null);

        rb.linearVelocity = gun.transform.up * bulletSpeed;
    }

    //void Effect()
    //{
    //    Transform clone = (Transform)Instantiate(muzzleFalshPrefab, effect.position, effect.rotation) as Transform;
    //    clone.parent = effect;
    //    float size = Random.Range(0.6f, 0.9f);
    //    clone.localScale = new Vector3(size, size, size);
    //    Destroy(clone.gameObject, 0.02f);
    //}
}
