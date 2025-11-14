using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    [Header("References")]
    public EnemyPool enemyPool;
    public Transform playerTransform;

    public float spawnInterval = 3f;

    Camera mCam;
    Vector2 spawnPos;
    Vector2 minSpawnSize;
    Vector2 maxSpawnSize;
    public float maxSpawnAreaMultiplier = 1.31f;

    private void Awake()
    {
        Instance = this;

        mCam = Camera.main;

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        InvokeRepeating(nameof(SpawnEnemies), 2f, spawnInterval);
    }

    private void Update()
    {
        spawnPos = mCam.transform.position;
        minSpawnSize = new Vector2(mCam.orthographicSize * 2f * mCam.aspect, mCam.orthographicSize * 2f);
        maxSpawnSize = minSpawnSize * maxSpawnAreaMultiplier;
    }

    void SpawnEnemies()
    {
        if (enemyPool != null && enemyPool.currentAvailableEnemies > 0)
        {
            float spawnX, spawnY;
            if (Random.Range(0f, 1f) < 0.5f)
            {
                // sað-sol
                spawnX = Random.Range(0f, 1f) < 0.5f ? Random.Range(minSpawnSize.x / 2, maxSpawnSize.x / 2) : -Random.Range(minSpawnSize.x / 2, maxSpawnSize.x / 2);
                spawnY = Random.Range(-maxSpawnSize.y / 2, maxSpawnSize.y / 2);
                Vector2 spawnPoint = new Vector2(spawnPos.x + spawnX, spawnPos.y + spawnY);
                Debug.Log($"Spawning enemy at {spawnPoint}");
                enemyPool.GetEnemy(spawnPoint, Quaternion.identity);
            }
            else
            {
                // üst-alt
                spawnY = Random.Range(0f, 1f) < 0.5f ? Random.Range(minSpawnSize.y / 2, maxSpawnSize.y / 2) : -Random.Range(minSpawnSize.y / 2, maxSpawnSize.y / 2);
                spawnX = Random.Range(-maxSpawnSize.x / 2, maxSpawnSize.x / 2);
                Vector2 spawnPoint = new Vector2(spawnPos.x + spawnX, spawnPos.y + spawnY);
                Debug.Log($"Spawning enemy at {spawnPoint}");
                enemyPool.GetEnemy(spawnPoint, Quaternion.identity);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(spawnPos, minSpawnSize);

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(spawnPos, maxSpawnSize);
    }
}
