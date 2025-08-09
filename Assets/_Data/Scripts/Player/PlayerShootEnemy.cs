using UnityEngine;

public class PlayerShootEnemy : MonoBehaviour
{
    private SpawnEnemy spawnEnemy;
    private Bullet bullet;
    [SerializeField] private float damagedBoss = 1f;


    private void Awake()
    {
        spawnEnemy = FindAnyObjectByType<SpawnEnemy>();
        bullet = FindAnyObjectByType<Bullet>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            spawnEnemy.EnemyDied();
            Destroy(collision.gameObject);
            GameManager.instance.DestroyEffect(collision.transform.position);

            bullet.Deactivate();
        }

        if (collision.CompareTag("Boss"))
        {
            HealthBar.instance.TakeDamage(damagedBoss);
            GameManager.instance.DestroyEffect(collision.transform.position);
        }
    }

}
