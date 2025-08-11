using UnityEngine;

public class BossShootPlayer : MonoBehaviour
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
                    collision.gameObject.SetActive(false);
                    Time.timeScale = 0;
                    UIManager.instance.gameOver.SetActive(true);
                }

            }
        }
    }
}
