using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject healthBarUI;
    public Slider healthBar;

    public float maxHealth = 100f;
    private float currentHealth;
    public static HealthBar instance;

    private void Awake()
    {
        instance = this;

        healthBarUI = UIManager.instance.bossHealthBarUI;
        healthBar = UIManager.instance.bosshealthBar;

    }

    void Start()
    {
        ShowHealthBar();
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    public void ShowHealthBar()
    {
        healthBarUI.SetActive(true);
    }


    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
