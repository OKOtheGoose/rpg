using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Perks : MonoBehaviour
{
    public static Perks instance;
    public PerkType[] ArrPerks = new PerkType[3];
    void Start()
    {
        instance = this;
    }
    public void giveSpeedEffect()
    {
        if(Movement.Instance.speed < Movement.Instance.MaxSpeed)
            StartCoroutine("GiveSpeedEffect");
    }   //SpeedEffect
    private IEnumerator GiveSpeedEffect()
    {
        if (Movement.Instance == null) { Debug.LogWarning("Movement is null" + Movement.Instance.speed); }
        Debug.Log(Movement.Instance.speed);
        Movement.Instance.speed += 1.5f;
        yield return new WaitForSeconds(5f);
        Movement.Instance.speed -= 1.5f;
    }   //SpeedEffect
    public void giveLeachEffect(float damage)
    {
        damage *= 0.5f;
        gameObject.GetComponent<Health>().GetDamage(-damage);
    }
    public void GiveEffect(PerkType type, float damage = 0)
    {
        var effectsCount = ArrPerks.Count(x => x == type);
        if (effectsCount != 0)
            switch (type)
            {
                case PerkType.Quickness:
                    for (var i = 0; i < effectsCount; i++)
                        giveSpeedEffect();
                break;
                case PerkType.Leach:
                    for (var i = 0; i < effectsCount; i++)
                        giveLeachEffect(damage);
                break;
            }
    }
}
public enum PerkType
{
    Leach = 1,
    Quickness = 2
}