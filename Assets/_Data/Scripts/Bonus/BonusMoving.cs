using UnityEngine;

public class BonusMoving : MonoBehaviour
{
    public float speed = 2f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
