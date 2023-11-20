using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perks : MonoBehaviour
{
    public static Perks instance;
    void Start()
    {
        instance = this;
    }
    void Update()
    {
        
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
        yield return new WaitForSeconds(3f);
        Movement.Instance.speed -= 1.5f;
    }   //SpeedEffect
    public void giveLeachEffect(float damage)
    {
        damage %= 10;
        gameObject.GetComponent<Health>().GetDamage(-damage);
    }
}