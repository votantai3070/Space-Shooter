using UnityEngine;

public class PlayerShootEnemy : MonoBehaviour
{
    private SpawnEnemy spawnEnemy;
    private Bullet bullet;
    [SerializeField] private int enemyScore = 10;

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
            UIManager.instance.CalculateScore(enemyScore);
            Destroy(collision.gameObject);
            GameManager.instance.DestroyEffect(collision.transform.position);

            bullet.Deactivate();
        }

        if (collision.CompareTag("Boss"))
        {
            HealthBar.instance.TakeDamage(GameSettings.instance.damageToBoss);
            GameManager.instance.DestroyEffect(collision.transform.position);

        }
    }

}
