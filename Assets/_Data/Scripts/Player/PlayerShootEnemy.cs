using UnityEngine;

public class PlayerShootEnemy : MonoBehaviour
{
    private SpawnEnemy spawnEnemy;
    private Bullet bullet;

    private void Awake()
    {
        spawnEnemy = FindAnyObjectByType<SpawnEnemy>();
        bullet = FindAnyObjectByType<Bullet>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Bullet hit enemy: " + collision.name);

            spawnEnemy.EnemyDied();

            Destroy(collision.gameObject);
            bullet.Deactivate();
        }
    }

}
