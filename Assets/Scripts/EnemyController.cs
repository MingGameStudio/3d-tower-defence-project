using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] int damage;
    public Vector3 movement;
    public EnemyPath enemyPath;

    [Header("Enemy Health")]
    [SerializeField] float maxHealth = 10;
    public float health;
    public Slider healthBar;
    public Renderer[] targetRenderer;
    private Material material;

    int currentPointIndex = 0;
    
    void Start()
    {
        health = maxHealth;
        healthBar.minValue = 0;
        healthBar.maxValue = health;
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

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void DealDamageToEnemy(int damage)
    {
        Debug.Log(" The enemy took " + damage + " hits ");
        health -= damage;
        healthBar.value = health;
    }
}
