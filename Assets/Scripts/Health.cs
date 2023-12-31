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
    public Inventory inventory;
    void Start()
    {
        health = MaxHealth;
        Status = PlayerState.Good;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && health < MaxHealth && inventory.HealthBottle >= 1)
        {
            GetDamage(-60);
            inventory.AddHealthBottle(-1);
        }   //����� ��������
    }
    public void GetDamage(float damage)
    {
        if (health > 0f)
        {
            health -= damage;
            //Perks.instance.SpeedEffect.Invoke();
            Perks.instance.GiveEffect(PerkType.Quickness);
            if (health < 0f)
            {
                health = 0f;
            }   //������� UI
            else if (health > MaxHealth) 
                health = MaxHealth;  //�������� ������ ������

            if (scrollBar != null)
            {
                scrollBar.size = health > 0 ? health / MaxHealth : 0f;
                Text.text = $"{(health > 0 ? System.Math.Round(health) : 0)}/{(int)System.Math.Round(MaxHealth)}";
            }   //UI
            if (health <= 0f) {
                Status = PlayerState.Dead;
                Movement.Instance.StatusUpdate(Status);
            }   //������
        }
        
    }
    public enum PlayerState 
    { 
        Good, Injured, Poisoned, Dead
    }

}