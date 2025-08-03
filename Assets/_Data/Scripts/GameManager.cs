using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public ParticleSystem effectPrefab;
    public GameObject levelUpPrefab;
    public Transform spawnLvlUpPrefab;
    private Transform[] spawnPoint;

    [SerializeField] private float levelUpTimer = 4f;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
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
            GameObject levelUp = Instantiate(levelUpPrefab, spawnPointTransform.position, Quaternion.identity);

            yield return new WaitForSeconds(levelUpTimer);
        }
    }
}
