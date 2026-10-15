using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] enemyPrefab;
    public float spawnInterval = 2; // How often enemy spawns ( starting value )
    public float spawnIntervalTimer = 0; // Timer ( that goes down )

    void Update()
    {
        spawnIntervalTimer -= Time.deltaTime;
        if (spawnIntervalTimer <= 0)
        {
            Instantiate(enemyPrefab[0], transform.position, transform.rotation);
            spawnIntervalTimer = spawnInterval;
        }
    }
}
