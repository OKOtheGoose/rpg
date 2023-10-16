using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Movement : MonoBehaviour
{
    public float speed;
    private Animator animator;
    public GameObject animatorobject;
    public Health health;
    static public Movement Instance;
    private bool isAbleToMove = true;

    private void Start()
    {
        Instance = this;
        animator = animatorobject.GetComponent<Animator>();
    }
    void Update()
    {
        if (!isAbleToMove) 
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            return;
        }
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");

        var newposition = new Vector3(horizontal * speed, vertical * speed, 0f);
        gameObject.GetComponent<Rigidbody2D>().velocity = newposition;
        if (horizontal > 0)
        {
            animator.SetFloat("Right", horizontal);
            animatorobject.GetComponent<SpriteRenderer>().flipX = false;
        }
        if (horizontal < 0)
        {
            animator.SetFloat("Right", -horizontal);
            animatorobject.GetComponent<SpriteRenderer>().flipX = true;
            if (vertical > 0)
            {
                animator.SetFloat("Forward", vertical);
            }
            else
            {
                animator.SetFloat("Forward", -vertical);
            }
        }
       
    }
    public void StatusUpdate(Health.PlayerState status)
    {
        if (status == Health.PlayerState.Dead)
        {
            animator.SetTrigger("Death");
            isAbleToMove = false;
            Invoke("RestartScene", 1.5f);
        }
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
