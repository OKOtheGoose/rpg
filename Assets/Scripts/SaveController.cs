using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveController : MonoBehaviour
{
    void Save()
    {
        int healthBottle = gameObject.GetComponent<Inventory>().HealthBottle;
        int money = gameObject.GetComponent<Inventory>().Money;

        PlayerPrefs.SetInt("HealthBottleCount", healthBottle);
        PlayerPrefs.SetInt("MoneyCount", money);

        for (int i = 0; i < Perks.instance.ArrPerks.Length; i++)
        {
            PlayerPrefs.SetInt($"Perks_{i}", (int)Perks.instance.ArrPerks[i]);
        }
        for (int i = 0; i < Buffs.instance.ArrBuffs.Count; i++)
        {
            PlayerPrefs.SetInt($"Buffs_{i}", (int)Buffs.instance.ArrBuffs[i]);
        }
        PlayerPrefs.SetInt("BuffAmount", Buffs.instance.ArrBuffs.Count);

        PlayerPrefs.Save();

        Debug.Log("Saved");
    }
    void Load()
    {
        gameObject.GetComponent<Health>().MaxHealth = 100;
        gameObject.GetComponent<Attack>().Damage = 20;
        gameObject.GetComponent<Inventory>().HealthBottle = PlayerPrefs.GetInt("HealthBottleCount", 0);
        gameObject.GetComponent<Inventory>().Money = PlayerPrefs.GetInt("MoneyCount", 0);


        for (int i = 0; i < Perks.instance.ArrPerks.Length; i++)
        {
            Perks.instance.ArrPerks[i] = (PerkType)PlayerPrefs.GetInt($"Perks_{i}");
        }
        Buffs.instance.ArrBuffs.Clear();
        for (int i = 0; i < PlayerPrefs.GetInt("BuffAmount"); i++)
        {
            Buffs.instance.AddBuff((BuffType)PlayerPrefs.GetInt($"Buffs_{i}"));
        }

        Debug.Log("Loaded");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.F9))
        {
            Load();
        }

    }
}
