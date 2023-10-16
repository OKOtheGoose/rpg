using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Movement")]
    public float Speed;
    public LayerMask layerMask;
    public float SearchRadius;
    public Transform LeftBottom;
    public Transform RightTop;
    public GameObject AnimatorObject;
    private Animator animator;
    private Rigidbody2D rb;
    private Vector3 spawnposition;
    private bool inRoom = true;
    private bool playerInRoom = false;
    public float SpawnPointDistance = 1f;
    [Header("Attack")]
    public float Damage;
    public float AttackRadius;
    public float AttackCooldown;
    private float curCooldown;
    public bool isAlive;
    void Start()
    {
        animator = AnimatorObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spawnposition = transform.position;
        curCooldown = AttackCooldown;
    }
    void FixedUpdate()
    {
        if (!isAlive)
        {
            return;
        }
        curCooldown -= Time.fixedDeltaTime;
        var colliders = Physics2D.OverlapCircleAll(transform.position, SearchRadius, layerMask);
        if (colliders.Length > 0)
        {
            if (LeftBottom.position.x <= colliders[0].transform.position.x && LeftBottom.position.y <= colliders[0].transform.position.y
                && RightTop.position.x >= colliders[0].transform.position.x && RightTop.position.y >= colliders[0].transform.position.y && inRoom)
            {
                Vector2 chaseDirection = colliders[0].transform.position - transform.position;
                if (chaseDirection.magnitude > AttackRadius)
                {   
                    rb.MovePosition(rb.position + chaseDirection.normalized * Speed * Time.fixedDeltaTime);
                    animator.SetBool("Walk", true);
                }
                else
                    animator.SetBool("Walk", false);

                if (colliders[0].transform.position.x < transform.position.x)
                {
                    AnimatorObject.GetComponent<SpriteRenderer>().flipX = true;
                }
                else
                {
                    AnimatorObject.GetComponent<SpriteRenderer>().flipX = false;
                }
                inRoom = true;
                playerInRoom = true;
            }
            else
            {
                    inRoom = false;
                if (playerInRoom)
                {
                    if (spawnposition.x < transform.position.x)
                    {
                        AnimatorObject.GetComponent<SpriteRenderer>().flipX = true;
                    }
                    else
                    {
                        AnimatorObject.GetComponent<SpriteRenderer>().flipX = false;
                    }
                    animator.SetBool("Walk", true);
                    Vector2 spawnpos = spawnposition - transform.position;
                    rb.MovePosition(rb.position + spawnpos.normalized * Speed / 2f * Time.fixedDeltaTime);
                }
                
                var spawn = Physics2D.OverlapCircleAll(spawnposition, SpawnPointDistance);
                if (spawn.Length > 0)
                {
                    inRoom = true;
                    playerInRoom = false;
                    animator.SetBool("Walk", false);
                }
            }
            if (colliders.Length == 0)
            {
                animator.SetBool("Walk", false);
            }
            if (curCooldown <= 0)
            {
                curCooldown = AttackCooldown;
                var attack = Physics2D.OverlapCircleAll(transform.position, AttackRadius, layerMask);
                if (attack.Length > 0)
                {
                    if (attack[0].GetComponent<Health>() != null)
                    {
                        attack[0].GetComponent<Health>().GetDamage(Damage);
                        animator.SetTrigger("Attack");
                    }
                }
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        // Draw detection radius in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, SearchRadius);
    }
}