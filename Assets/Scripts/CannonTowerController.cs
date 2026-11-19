using UnityEngine;

public class CannonTowerController : MonoBehaviour
{
    [SerializeField] float shootingRange = 10f;
    GameObject target = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    GameObject closestEnemy = null;
    public GameObject cannon;
    public float shootCooldown = 1f;
    float cooldownTimer = 0f;

    public Transform shootingPoint;
    public GameObject cannonballPrefab;
    // a member variable to store the closest enemy
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        ShootAtEnemy(Time.deltaTime);
    }

    void ShootAtEnemy(float deltaTime)
    {
        if (closestEnemy == null)
        {
            closestEnemy = FindClosestEnemy();
        }
        if (closestEnemy != null)
        {
            float currentDistance = Vector2.Distance(closestEnemy.transform.position, this.transform.position);
            if (currentDistance > shootingRange)
            {
                closestEnemy = null;
            }
            //closestEnemy.transform.localScale = new Vector3(2, 2, 2);
            cannon.transform.LookAt(closestEnemy.transform);

        if(cooldownTimer <= 0)
        {
            cooldownTimer = shootCooldown;
            Debug.Log("Shoot");
            Shoot();
        }
        else
        {
            cooldownTimer -= Time.deltaTime;
        }
        }
        // implement shoting logic here
    }

    void Shoot()
    {
        Instantiate(cannonballPrefab, shootingPoint.position, shootingPoint.rotation)
        .GetComponent<CannonballController>().target = closestEnemy.transform;
    }

    GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = shootingRange;

        for(int i = 0; i < enemies.Length; i++)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemies[i].transform.position);
            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                target = enemies[i];
            }
        }
        // implement logic to find the closest enemy
        return target;
    }

    
}
