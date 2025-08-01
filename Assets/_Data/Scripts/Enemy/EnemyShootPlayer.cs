using UnityEngine;

public class EnemyShootPlayer : MonoBehaviour
{
    private Bullet bullet;

    private void Awake()
    {
        bullet = FindAnyObjectByType<Bullet>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            bullet.Deactivate();
        }
    }
}
