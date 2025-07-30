using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform[] waypoints;
    private int currentWaypointIndex = 0;
    public float speed = 2f;
    private SpawnEnemy spawner;

    public void SetPath(Transform path)
    {
        waypoints = new Transform[path.childCount];
        for (int i = 0; i < path.childCount; i++)
        {
            waypoints[i] = path.GetChild(i);
        }
    }

    public void SetSpawner(SpawnEnemy spawnerRef)
    {
        spawner = spawnerRef;
    }

    void Update()
    {
        if (waypoints == null || currentWaypointIndex >= waypoints.Length)
        {
            spawner.EnemyDied();
            Destroy(gameObject);
            return;
        }

        Transform target = waypoints[currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            currentWaypointIndex++;
        }
    }
}
