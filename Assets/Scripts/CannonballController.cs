using UnityEngine;

public class CannonballController : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    public int bulletDamage = 3;

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 destination = target.position;

            transform.position = Vector3.MoveTowards(
            transform.position, destination, speed * Time.deltaTime
        );
            if (Vector3.Distance(transform.position, destination) < 0.05f)
            {
                target.GetComponent<EnemyController>().DealDamageToEnemy(bulletDamage);
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
