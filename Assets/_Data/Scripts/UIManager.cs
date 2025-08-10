using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject bossHealthBarUI;
    public Slider bosshealthBar;
    public TextMeshProUGUI playerLifeText;
    public TextMeshProUGUI scoreText;
    public GameObject gameOver;
    public GameObject mainMenu;
    public GameObject settingUI;

    private int currentScore;
    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        gameOver.SetActive(false);
        scoreText.text = 0.ToString();
        if (bossHealthBarUI != null)
        {
            HideHealthBar();
        }
    }

    public void HideHealthBar()
    {
        bossHealthBarUI.SetActive(false);
    }

    public void CalculateScore(int score)
    {
        currentScore += score;
        scoreText.text = currentScore.ToString();
    }

    public void OpenSetting()
    {
        settingUI.SetActive(true);
        mainMenu.SetActive(false);
        gameOver.SetActive(false);
        Time.timeScale = 0;
    }

    public void CloseSetting()
    {
        settingUI.SetActive(false);
        mainMenu.SetActive(true);
        gameOver.SetActive(false);
        Time.timeScale = 0;
    }
}
