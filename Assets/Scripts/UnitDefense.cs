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
                Instantiate(item, transform.position + new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), 0), Quaternion.identity);
            }
        }
    }
}