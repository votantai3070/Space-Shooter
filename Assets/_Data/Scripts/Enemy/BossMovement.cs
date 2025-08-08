using UnityEngine;

public class BossMovement : MonoBehaviour
{
    private Transform spawnPoint;
    private Transform movePoint;
    private Transform startPoint;
    private Transform endPoint;

    [SerializeField] private float speed = 5f;
    private Transform currentTarget;
    private bool hasReachedMovePoint = false;

    private void Start()
    {
        spawnPoint = GameObject.Find("SpawnPoint").transform;
        movePoint = GameObject.Find("MovePoint").transform;
        startPoint = GameObject.Find("StartPoint").transform;
        endPoint = GameObject.Find("EndPoint").transform;

        transform.position = spawnPoint.position;
        currentTarget = movePoint;
    }

    private void Update()
    {
        BossMove();
    }

    private void BossMove()
    {
        transform.position = Vector3.MoveTowards(
           transform.position,
           currentTarget.position,
           speed * Time.deltaTime
       );

        if (!hasReachedMovePoint && Vector3.Distance(transform.position, movePoint.position) < 0.01f)
        {
            hasReachedMovePoint = true;
            currentTarget = startPoint;
        }

        if (hasReachedMovePoint)
        {
            if (Vector3.Distance(transform.position, startPoint.position) < 0.01f)
            {
                currentTarget = endPoint;
            }
            else if (Vector3.Distance(transform.position, endPoint.position) < 0.01f)
            {
                currentTarget = startPoint;
            }
        }
    }
}
