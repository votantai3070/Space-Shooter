using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public static PlayerLife instance;
    public int playerLife => GameSettings.instance.playerLives;



    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UIManager.instance.playerLifeText.text = playerLife.ToString();
    }

    public void UpdatePlayerLife()
    {
        GameSettings.instance.playerLives -= 1;
        UIManager.instance.playerLifeText.text = playerLife.ToString();
    }
}
