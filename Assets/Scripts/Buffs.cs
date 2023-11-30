using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Buffs : MonoBehaviour
{
    public static Buffs instance;
    public List<BuffType> ArrBuffs;
    void Start()
    {
        instance = this;
    }
    public void AddBuff(BuffType type)
    {
        ArrBuffs.Add(type);
        ApplyBuff(type);
    }
    public void ApplyBuff(BuffType type)
    {
            switch (type)
            {
                case BuffType.Damage:
                        giveDamage();
                    break;
                case BuffType.Health:
                        giveHealth();
                    break;
            }
    }
    void giveDamage()
    {
        Movement.Instance.gameObject.GetComponent<Attack>().Damage *= 1.15f;
    }
    void giveHealth()
    {
        Movement.Instance.gameObject.GetComponent<Health>().MaxHealth *= 1.15f;
        Movement.Instance.gameObject.GetComponent<Health>().health += 0;
    }
}
public enum BuffType
{
    Damage = 1,
    Health = 2
}