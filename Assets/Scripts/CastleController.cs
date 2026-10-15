using UnityEngine;

public class CastleController : MonoBehaviour
{
    public int health = 100;

    public void DealDamageToCastle(int damage)
    {
        Debug.Log(" The castle took " + damage + " hits ");
        if (damage > 10)
        {
            Debug.Log("That's gotta hurt!");
        }
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
