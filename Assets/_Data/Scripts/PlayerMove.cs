using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f; // Speed of the player movement
    private Vector3 targetPos;
    private bool isMoving = false;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.WorldToScreenPoint(transform.position).z; // Set the z position to the player's z position

            targetPos = Camera.main.ScreenToWorldPoint(mousePos);
            targetPos.z = transform.position.z; // Keep the player's z position unchanged
            isMoving = true;
        }

        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPos) < 0.01f)
            {
                isMoving = false; // Stop moving when close to the target position
            }
        }
    }
}
