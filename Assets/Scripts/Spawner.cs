using System.Collections.Generic;
using System;
using UnityEngine;

public class Spawner
{
    public int ItemsCount;

    public Dictionary<int, GameObject> SpawnProbabilityDict;

    public void SpawnObjects()
    {
        var rand = new System.Random();
        var itemsCount = 3;
        while (itemsCount < ItemsCount)
        {
            foreach (var prob in SpawnProbabilityDict.Keys)
            {
                var randNum = rand.Next(0, 100);
                if (randNum < prob)
                {
                    Console.WriteLine($"Spawned {SpawnProbabilityDict[prob]}, rand num: {randNum}");
                    itemsCount++;
                }

                if (itemsCount >= ItemsCount)
                    break;
            }
        }
    }
}