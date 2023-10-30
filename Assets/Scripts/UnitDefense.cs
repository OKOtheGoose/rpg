using System;
using UnityEngine;

public class UnitDefense : MonoBehaviour
{
    public float MaxHealth;
    public float health;
    public Animator animator;
    public GameObject item;
    void Start()
    {
        health = MaxHealth;
        
    }
    public void GetDamage(float damage)
    {
        if (health > 0f)
        {
            health -= damage;
            if(damage >= 5%health) 
            {
                animator?.SetTrigger("Damage"); 
            }
            if (health <= 0f)
            {
                
                if(gameObject.GetComponent<Enemy>() != null)
                    gameObject.GetComponent<Enemy>().isAlive = false;
                animator?.SetTrigger("Death");
                Destroy(gameObject, 3);
                GetComponent<Spawn>().SpawnProbs();
            }
        }
    }
}