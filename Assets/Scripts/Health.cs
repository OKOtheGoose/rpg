using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float MaxHealth;
    public float health;
    public Scrollbar scrollBar;
    public TextMeshProUGUI Text;
    static public PlayerState Status;
    void Start()
    {
        health = MaxHealth;
        Status = PlayerState.Good;
    }
    public void GetDamage(float damage)
    {
        if (health > 0f)
        {
            health -= damage;
            if (scrollBar != null)
            {
                scrollBar.size = health > 0 ? health / MaxHealth : 0f;
                Text.text = $"{(health > 0 ? health : 0)}/{MaxHealth}";

            }
            if (health <= 0f) {
                Status = PlayerState.Dead;
                Movement.Instance.StatusUpdate(Status);
            }
        }
    }
    public enum PlayerState 
    { 
        Good, Injured, Poisoned, Dead
    }

}