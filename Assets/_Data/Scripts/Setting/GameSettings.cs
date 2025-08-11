using UnityEngine;

[System.Serializable]
//public class GameSettingsData
//{
//    public int playerLives = 3;
//    public float playerSpeed = 5f;
//    public float playerFireRate = 0.5f;
//    public float playerBulletSpeed = 10f;
//    public int enemySpawn = 5;
//    public float enemySpeed = 2f;
//    public float enemyBulletSpeed = 5f;
//    public float enemyFireRate = 1f;
//    public float damageToBoss = 2f;
//    public float bossSpeed = 1f;
//}


public class GameSettings : MonoBehaviour
{
    public int playerLives = 3;
    public float playerSpeed = 5f;
    public float playerFireRate = 0.5f;
    public float playerBulletSpeed = 10f;
    public int enemySpawn = 5;
    public float enemySpeed = 2f;
    public float enemyBulletSpeed = 5f;
    public float enemyFireRate = 1f;
    public float damageToBoss = 2f;
    public float bossSpeed = 1f;
    public static GameSettings instance;
    [SerializeField] private int defaultPlayerLives = 3;

    //public GameSettingsData gameSettingsData = new GameSettingsData();
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
            ResetLives();
        }
        else
        {
            Destroy(gameObject);
        }

    }



    public void ResetLives()
    {
        defaultPlayerLives = playerLives;
    }
}
