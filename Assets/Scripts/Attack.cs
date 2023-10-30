using UnityEngine;

public class Attack : MonoBehaviour
{
    public float Damage;
    public float Speed;
    public float Radius;
    public GameObject animatorobject;
    public LayerMask AttackMask;
    private float Cooldown;
    public float MaxCooldown;
    void Start()
    {

    }
    void Update()
    {
        Cooldown -= Speed * Time.deltaTime;


            if (Input.GetMouseButton(0))
            {
                if (Cooldown <= 0)
                {
                    Cooldown = MaxCooldown;
                    animatorobject.GetComponent<Animator>().SetTrigger("Slash");
                    Invoke("DoDamage", 0.2f);
                }
            }
    }
    private void OnDrawGizmosSelected()
    {
        // Draw detection radius in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Radius); 
    }
    void DoDamage()
    {
        var enemies = Physics2D.OverlapCircleAll(transform.position - new Vector3(animatorobject.GetComponent<SpriteRenderer>().flipX ? Radius / 2 : -Radius / 2, 0, 0), Radius, AttackMask);
        foreach (var enemy in enemies)
        {

            enemy.GetComponent<UnitDefense>()?.GetDamage(Damage);

        }
    }
}
