using UnityEngine;

public class EnemyShootPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!BlinkEffect.instance.isBlinking)
            {
                if (PlayerLife.instance.playerLife > 0)
                {
                    BlinkEffect.instance.StartBlinkEffect();
                    PlayerLife.instance.UpdatePlayerLife();
                }
                else if (PlayerLife.instance.playerLife <= 0)
                {
                    GameManager.instance.DestroyEffect(collision.transform.position);
                    Destroy(collision.gameObject);
                    UIManager.instance.gameOver.SetActive(true);
                }
                Bullet.instance.Deactivate();
            }
        }
    }
}
