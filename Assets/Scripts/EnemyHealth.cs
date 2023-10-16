using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float MaxHealth;
    public float health;
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

                gameObject.GetComponent<Enemy>().AnimatorObject.GetComponent<Animator>().SetTrigger("Damage"); 
            }
            if (health <= 0f)
            {
                gameObject.GetComponent<Enemy>().isAlive = false;
                gameObject.GetComponent<Enemy>().AnimatorObject.GetComponent<Animator>().SetTrigger("Death");
                Destroy(gameObject, 3);
            }
        }
    }
}