using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CastleController : MonoBehaviour
{
    [SerializeField] float maxHealth = 100;
    public float health;
    public Slider healthBar;
    public Renderer targetRenderer;
    private Material[] materials;


    void Awake()
    {
        
        materials = targetRenderer.materials;
    }

    public void DealDamageToCastle(int damage)
    {
        Debug.Log(" The castle took " + damage + " hits ");
        if (damage > 10)
        {
            Debug.Log("OOOOOF");
        }
        health -= damage;
        healthBar.value = health;

        StartCoroutine(FlashCoroutine());

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

    IEnumerator FlashCoroutine()
    {
        foreach (Material HitEffect in materials)
        if (HitEffect != null && HitEffect.HasProperty("_BlendValue"))
            HitEffect.SetFloat("_BlendValue", 10);

        yield return new WaitForSeconds(0.1f);

        foreach (Material HitEffect in materials)
        if (HitEffect != null && HitEffect.HasProperty("_BlendValue"))
            HitEffect.SetFloat("_BlendValue", 0);
        
    }

    
}
