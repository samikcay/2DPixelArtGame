using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool Instance { get; private set; }
    Queue<GameObject> enemyPool;
    public GameObject enemyPrefab;
    public int poolSize = 20;
    public int currentAvailableEnemies;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        enemyPool = new Queue<GameObject>(poolSize);
        currentAvailableEnemies = 0;
        PopulatePool();
    }

    private void Update()
    {

    }

    public GameObject GetEnemy(Vector3 position, Quaternion rotation)
    {
        if (enemyPool.Count > 0)
        {
            GameObject enemy = enemyPool.Dequeue();
            enemy.transform.position = position;
            enemy.transform.rotation = rotation;
            enemy.SetActive(true);
            currentAvailableEnemies--;
            return enemy;
        }
        else
        {
            return Instantiate(enemyPrefab, position, rotation);
        }
    }

    public void ReturnEnemy(GameObject enemy)
    {
        enemy.SetActive(false);
        currentAvailableEnemies++;
        enemyPool.Enqueue(enemy);
    }

    private void PopulatePool()
    {
        if (enemyPrefab == null)
        {
            Debug.LogError("Enemy Prefab is not assigned in the EnemyPool script.");
            return;
        }
        for (int i = 0; i < 20; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            currentAvailableEnemies++;
            enemyPool.Enqueue(enemy);
        }
    }
}
