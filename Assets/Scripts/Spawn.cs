using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [Header("Coin")]
    public GameObject Coin;
    public int CoinProb;
    [Header("HealthBottle")]
    public GameObject HealthBottle;
    public int HealthProb;
    public void SpawnProbs()
    {
        var spawner = new Spawner();
        spawner.ItemsCount = 5;
        spawner.SpawnProbabilityDict = new Dictionary<int, GameObject>()
        {
            [CoinProb] = Coin,
            [HealthProb] = HealthBottle,
        };
        spawner.SpawnObjects();
    }
}
