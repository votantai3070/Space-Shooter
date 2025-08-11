using UnityEngine;
using DG.Tweening;

public class PlayerMove : MonoBehaviour
{
    protected Vector3 worldPosition;


    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            worldPosition = InputManager.instance.mousePos;
            worldPosition.z = 0;

            // Move the player towards the mouse position
            Vector3 newPos = Vector3.Lerp(transform.parent.position, worldPosition, GameSettings.instance.playerSpeed * Time.deltaTime);
            transform.parent.position = newPos;
        }
    }
}
