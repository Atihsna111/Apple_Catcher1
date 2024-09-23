using UnityEngine;
public class Trigger : MonoBehaviour
{
    [SerializeField] GameObject point;
    [SerializeField] GameObject ObstaclePrefab;
    groundSpawner spawner;
    [SerializeField] Vector3 offsetObstacle;
    void Start()
    {
        spawner = GameObject.FindObjectOfType<groundSpawner>();
        SpawnObstacle();
        Spawnpoints();
    }

    private void OnTriggerExit(Collider other)
    {
        spawner.ShouldSpawn();
        //to destroy obstacle
        Destroy(gameObject);
    }

    void SpawnObstacle()
    {
        //Choose a random point to spawn the obstacle
        int obstacleSpawnIndex = Random.Range(2,5);
        Transform spawnPoint = transform. GetChild(obstacleSpawnIndex).transform;
        //Spawn the obstacle at the position

        GameObject temp =Instantiate(ObstaclePrefab, spawnPoint.position, Quaternion.identity);// this is for the obstacle,  
        temp.transform.Rotate(offsetObstacle);//prefab rotation 
    }
    void Spawnpoints()
    {
        int pointsToSpawn = 5;
        Collider collider= GetComponent<Collider>();
        for(int i = 0; i < pointsToSpawn; i++ )
        {
            GameObject temp = Instantiate(point, transform);
            temp.transform.position= GetRandomPointInCollider(collider);
        }

        Vector3 GetRandomPointInCollider(Collider collider)
        {
            Vector3 point;
            Bounds bounds = collider.bounds;
            do
            {
            //x-axis how far left(min) the coin can go, how far right(max) it can go, y-aixs (min) how far down it can go & (max) is how far up it can go,z-axis (min) how far back it goes and (max) how far forward it can go
            point = new Vector3( 
                Random.Range(bounds.min.x-2, bounds.max.x -2), 
                Random.Range(bounds.min.y, bounds.max.y), 
                Random.Range(bounds.min.z, bounds.max.z));
            }//incase the point is not on collider
            while(point != collider.ClosestPoint(point));

            point.y =0.78f;
            return point;
        }
    }
}
