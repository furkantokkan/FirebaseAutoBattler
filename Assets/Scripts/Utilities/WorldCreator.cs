using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFSW.QC;
using System;
using UnityEngine.Analytics;
using Firebase.Firestore;

public class WorldCreator : MonoBehaviour
{
#if UNITY_EDITOR

    [Command("world-x")] public int Width = 25;
    [Command("world-y")] public int Height = 25;

    FirebaseFirestore firestore;

    private void Start()
    {
       firestore = FirebaseFirestore.DefaultInstance;
    }

    [Command("create-world")]
    private void CreateWorld()
    {
        StartCoroutine(CreateWorlds());
    }

    [Command("create-shops")]
    private void CreateShop()
    {
        StartCoroutine(CreateShops());
    }

    private IEnumerator CreateWorlds()
    {
        Debug.Log("Creating Worlds");
        int neigbourCount = 0;

        for (int w = 0; w < Width; w++)
        {
            for (int h = 0; h < Height; h++)
            {
                neigbourCount++;

                var newNeighbourhood = new FirestoreNeighbourhoodData()
                {
                    worldID = "w1",
                    neighbourhoodName = $"Neighbourhood #{neigbourCount}",
                    x = w,
                    y = h,
                    OwnerID = "",
                    ownerName = ""

                };
                Debug.Log("Creating Neighbourhood " + newNeighbourhood.neighbourhoodName + " at " + newNeighbourhood.x + "x" + newNeighbourhood.y);
                var addNeighbourhoodTask = firestore.Collection("worlds").AddAsync(newNeighbourhood);
                yield return new WaitUntil(() => addNeighbourhoodTask.IsCompleted);
            }
        }

        Debug.Log("Worlds Created");
    }

    private IEnumerator CreateShops()
    {
        yield break;
    }


#endif
}
