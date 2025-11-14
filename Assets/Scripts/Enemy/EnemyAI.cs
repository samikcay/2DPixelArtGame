using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Transform playerPos;
    public float moveSpeed = 3f;

    private void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (playerPos != null)
        {
            Vector2 direction = (playerPos.position - transform.position).normalized;
            transform.position += moveSpeed * Time.deltaTime * new Vector3(direction.x, direction.y, 0);
        }
    }
}
