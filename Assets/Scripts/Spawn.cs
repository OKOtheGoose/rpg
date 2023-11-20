using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public int ItemsCount;
    public List<Probability> Probabilities;

    public void SpawnProbs()
    {
        SpawnObjects();
    }

    public void SpawnObjects()
    {
        var rand = new System.Random();
        var itemsCount = 0;
        while (itemsCount < ItemsCount)
        {
            foreach (var prob in Probabilities)
            {
                var randNum = rand.Next(0, 100);
                if (randNum < prob.ProbabilityInPercent)
                {
                    Instantiate(prob.GameObject, transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0), Quaternion.identity);

                    itemsCount++;
                }

                if (itemsCount >= ItemsCount)
                    break;
            }
        }
    }
    [System.Serializable]
    public struct Probability
    {
        public GameObject GameObject;
        public int ProbabilityInPercent;
    }
}