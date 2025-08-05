using UnityEngine;

public class BonusPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Shooter.instance.lvlUpGun < Shooter.instance.maxLvlUpGun)
            {
                Shooter.instance.lvlUpGun++;
            }
            Destroy(gameObject);
        }

    }
}
