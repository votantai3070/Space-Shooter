using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public ParticleSystem effectPrefab;
    public GameObject levelUpPrefab;
    public Transform spawnLvlUpPrefab;
    public GameObject player;
    public GameObject[] enemies;

    private Transform[] spawnPoint;

    [SerializeField] private float levelUpTimer = 4f;

    private void Awake()
    {
        instance = this;
        Time.timeScale = 0;
    }

    private void Start()
    {
        Debug.Log(Application.persistentDataPath);
        player.SetActive(false);
        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(false);
        }
        UIManager.instance.playerLifeText.gameObject.SetActive(false);
        UIManager.instance.scoreText.gameObject.SetActive(false);
        UIManager.instance.settingUI.SetActive(false);

        StartCoroutine(SpawnLevelUp());
    }

    public void DestroyEffect(Vector3 position)
    {
        ParticleSystem effect = Instantiate(effectPrefab, position, Quaternion.identity);
        effect.Play();

        Destroy(effect.gameObject, effect.main.duration);
    }

    IEnumerator SpawnLevelUp()
    {

        spawnPoint = new Transform[spawnLvlUpPrefab.childCount];

        for (int i = 0; i < spawnLvlUpPrefab.childCount; i++)
        {
            spawnPoint[i] = spawnLvlUpPrefab.GetChild(i);
        }

        while (true)
        {
            int randomIndex = Random.Range(0, spawnPoint.Length);
            Transform spawnPointTransform = spawnPoint[randomIndex];
            Instantiate(levelUpPrefab, spawnPointTransform.position, Quaternion.identity);

            yield return new WaitForSeconds(levelUpTimer);
        }
    }

    public void PlayGame()
    {
        UIManager.instance.mainMenu.SetActive(false);
        UIManager.instance.gameOver.SetActive(false);
        player.SetActive(true);
        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(true);
        }
        UIManager.instance.playerLifeText.gameObject.SetActive(true);
        UIManager.instance.scoreText.gameObject.SetActive(true);

        Time.timeScale = 1;


    }

    public void GoToMenu()
    {
        UIManager.instance.gameOver.SetActive(false);
        UIManager.instance.mainMenu.SetActive(true);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void GameOver()
    {
        Scene scene = SceneManager.GetActiveScene();
        GameSettings.instance.ResetLives();
        SceneManager.LoadScene(scene.name);
    }
}
