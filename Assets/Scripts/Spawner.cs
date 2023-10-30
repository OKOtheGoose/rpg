using System.Collections.Generic;
using System;
using UnityEngine;
using static UnityEditor.Progress;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Spawner : MonoBehaviour
{
    public int ItemsCount;

    public Dictionary<int, GameObject> SpawnProbabilityDict;

    public void SpawnObjects()
    {
        var rand = new System.Random();
        var itemsCount = 0;
        while (itemsCount < ItemsCount)
        {
            foreach (var prob in SpawnProbabilityDict.Keys)
            {
                var randNum = rand.Next(0, 100);
                if (randNum < prob)
                {
                    Instantiate(SpawnProbabilityDict[prob], transform.position + new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), 0), Quaternion.identity);
                    Debug.Log(SpawnProbabilityDict[prob]);
                    itemsCount++;
                }

                if (itemsCount >= ItemsCount)
                    break;
            }
        }
    }
}