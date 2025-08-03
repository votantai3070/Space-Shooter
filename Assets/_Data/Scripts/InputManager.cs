using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    [SerializeField] public Vector3 mousePos;


    private void Awake()
    {
        instance = this;
    }

    private void FixedUpdate()
    {
        GetMousePos();
    }

    protected void GetMousePos()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
