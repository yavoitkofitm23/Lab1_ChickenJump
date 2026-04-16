using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;   
    public float spawnInterval = 1.5f; 
    public float minX = -2.5f;         
    public float maxX = 2.5f;           

    private float nextSpawnY;           

    void Start()
    {
        nextSpawnY = -3f;
        for (int i = 0; i < 10; i++)
        {
            SpawnPlatform();
        }
    }

    void Update()
    {
        float cameraTop = Camera.main.transform.position.y +
                          Camera.main.orthographicSize + 2f;

        while (nextSpawnY < cameraTop)
        {
            SpawnPlatform();
        }
    }

    void SpawnPlatform()
    {
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPos = new Vector3(randomX, nextSpawnY, 0f);

        Instantiate(platformPrefab, spawnPos, Quaternion.identity);

        nextSpawnY += Random.Range(spawnInterval * 0.7f, spawnInterval * 1.3f);
    }
}
