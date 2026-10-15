using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] int damage;
    public Vector3 movement;
    public EnemyPath enemyPath;

    int currentPointIndex = 0;
    
    void Start()
    {
        if (enemyPath == null)
        {
            enemyPath = FindFirstObjectByType<EnemyPath>();
        }
    }
    void Update()
    {
        if (currentPointIndex >= enemyPath.pathPoints.Length)
        {
            CastleController castle = FindFirstObjectByType<CastleController>();
            if (castle != null)
            {
                castle.DealDamageToCastle(damage);
            }
            Destroy(gameObject);
            return; // is this return necessary to stop further execution?
        }

        Transform targetPoint = enemyPath.pathPoints[currentPointIndex];
        movement = (targetPoint.position - transform.position).normalized * moveSpeed;
        transform.Translate(movement * Time.deltaTime);

        float distanceToTarget = Vector3.Distance(transform.position, targetPoint.position);
        if (distanceToTarget < 0.01f)
        {
            currentPointIndex++;
        }
    }
}
