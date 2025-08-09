using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject bossHealthBarUI;
    public Slider bosshealthBar;
    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (bossHealthBarUI != null)
        {
            HideHealthBar();
        }
    }

    public void HideHealthBar()
    {
        bossHealthBarUI.SetActive(false);
    }
}
