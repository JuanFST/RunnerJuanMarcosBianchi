
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;


    private void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacle();
        SpawnCoins();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }

    public GameObject obstaclePrefab;

    void SpawnObstacle ()
    {
        //elegir punto random
        int ObstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(ObstacleSpawnIndex).transform;

        //Spawnear el obtaculo en la posicion
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }
    public GameObject coinPrefab;

    void SpawnCoins()
    {
        int coinsToSpawn = 30;
        for (int i = 0; i < coinsToSpawn; i++) ;
        {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
          );
        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
    }


}
