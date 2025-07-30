using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    protected float speed = 5f;
    protected Vector3 worldPosition;

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPosition.z = 0;

            Vector3 newPos = Vector3.Lerp(transform.position, worldPosition, speed * Time.deltaTime);
            transform.position = newPos;
        }

    }
}
