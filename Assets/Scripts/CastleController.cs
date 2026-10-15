using UnityEngine;
using UnityEngine.UI;

public class CastleController : MonoBehaviour
{
    [SerializeField] float maxHealth = 100;
    public float health;
    public Slider healthBar;
    

    public void DealDamageToCastle(int damage)
    {
        Debug.Log(" The castle took " + damage + " hits ");
        if (damage > 10)
        {
            Debug.Log("That's gotta hurt!");
        }
        health -= damage;
        healthBar.value = health;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        health = maxHealth;
        healthBar.minValue = 0;
        healthBar.maxValue = health;
    }
    void Update()
    {
        
    }
}
