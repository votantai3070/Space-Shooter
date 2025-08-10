using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform[] waypoints;
    private int currentWaypointIndex = 0;
    private SpawnEnemy spawner;

    private Vector3 startPoint;
    private Vector3 endPoint;
    private float journeyLength;
    private float journeyTime;
    private float startTime;

    private bool isMovingParabola = false;




    public void SetPath(Transform path)
    {
        if (path == null || path.childCount == 0)
        {
            Debug.LogError("Path is null or has no waypoints!");
            return;
        }

        waypoints = new Transform[path.childCount];
        for (int i = 0; i < path.childCount; i++)
        {
            waypoints[i] = path.GetChild(i);
        }

        currentWaypointIndex = 0; // reset index
        SetupNextParabola();
    }

    public void SetSpawner(SpawnEnemy spawnerRef)
    {
        spawner = spawnerRef;
    }

    void Update()
    {
        if (waypoints == null || currentWaypointIndex >= waypoints.Length)
        {
            spawner?.EnemyDied();
            Destroy(gameObject);
            return;
        }

        MoveParabola();
    }

    void SetupNextParabola()
    {
        if (waypoints == null || currentWaypointIndex >= waypoints.Length || waypoints[currentWaypointIndex] == null)
        {
            Debug.LogWarning("No valid waypoint found, stopping movement.");
            isMovingParabola = false;
            return;
        }

        startPoint = transform.position;
        endPoint = waypoints[currentWaypointIndex].position;

        float speed = (GameSettings.instance != null)
            ? GameSettings.instance.enemySpeed
            : 2f; // default fallback

        journeyLength = Vector3.Distance(startPoint, endPoint);
        journeyTime = speed != 0 ? journeyLength / speed : 1f;
        startTime = Time.time;
        isMovingParabola = true;
    }

    void MoveParabola()
    {
        if (!isMovingParabola) return;

        if (journeyTime <= 0f)
        {
            transform.position = endPoint;
            currentWaypointIndex++;
            SetupNextParabola();
            return;
        }

        float t = (Time.time - startTime) / journeyTime;

        if (t >= 1f)
        {
            transform.position = endPoint;
            currentWaypointIndex++;
            SetupNextParabola();
            return;
        }

        // Tính vị trí theo parabol (trục cong là Y)
        Vector3 flatPos = Vector3.Lerp(startPoint, endPoint, t);
        float height = 2f;
        float parabola = 4 * height * (t - t * t); // công thức y = 4h(t - t^2)

        flatPos.y += parabola;

        // Kiểm tra NaN
        if (float.IsNaN(flatPos.x) || float.IsNaN(flatPos.y) || float.IsNaN(flatPos.z))
        {
            return;
        }

        transform.position = flatPos;
    }
}
