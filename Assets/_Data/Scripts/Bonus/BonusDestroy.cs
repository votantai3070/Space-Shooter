using UnityEngine;

public class BonusDestroy : MonoBehaviour
{
    public float lifeTime = 5f;

    void Start()
    {
        Invoke("DestroyBonus", lifeTime);
    }

    private void DestroyBonus()
    {
        Destroy(gameObject);
    }
}
