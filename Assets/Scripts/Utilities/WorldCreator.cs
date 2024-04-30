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

    [SerializeField] private ShopImages[] ShopImages;

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
                    WorldID = "w1",
                    NeighbourhoodName = $"Neighbourhood #{neigbourCount}",
                    X = w,
                    Y = h,
                    OwnerID = "",
                    OwnerName = ""

                };
                Debug.Log("Creating Neighbourhood " + newNeighbourhood.NeighbourhoodName + " at x:" + newNeighbourhood.X + " y:" + newNeighbourhood.Y);
                var addNeighbourhoodTask = firestore.Collection("worlds").AddAsync(newNeighbourhood);
                yield return new WaitUntil(() => addNeighbourhoodTask.IsCompleted);

                if (addNeighbourhoodTask.IsCompleted)
                {
                    yield return CreateShops(addNeighbourhoodTask.Result.Id);
                }
                else
                {
                    Debug.Log("Neigbourhood cannot be created");
                }
            }
        }

        Debug.Log("Worlds Created");
    }

    private IEnumerator CreateShops(string neighbourhoodID)
    {
        int numberOfShopes = UnityEngine.Random.Range(GameConst.minShopPerNeighbourhood, GameConst.maxShopPerNeighbourhood);

        int selectesShope;
        int avatarIndex;
        int tributecollectionDuration;
        int tributeCollectionAmount;
        string owner = "";


        Debug.Log("Creating Shops for Neighbourhood " + neighbourhoodID + " Amount: " + numberOfShopes);

        for (int i = 0; i < numberOfShopes; i++)
        {
            //shope and avatar selection

            selectesShope = UnityEngine.Random.Range(0, ShopImages.Length);

            avatarIndex = UnityEngine.Random.Range(0, ShopImages[selectesShope].shopImages.Length);

            //tribute collection duration

            tributecollectionDuration = UnityEngine.Random.Range(GameConst.minTributeCollectionDuration, GameConst.maxTributeCollectionDuration);


            //tribute collection amount

            tributeCollectionAmount = UnityEngine.Random.Range(GameConst.minTributeCollectionAmount, GameConst.maxTributeCollectionAmount);


            //Owner

            if (UnityEngine.Random.Range(0f, 1f) <= 0.2f) //20% chance of having an owner
            {
                owner = "BANDITS";
            }
            else
            {
                owner = "";
            }

           var shop = new FirestoreNeighbourhoodShopData()
           {
               ShopType = ShopImages[selectesShope].shopName,
               AvatarIndex = avatarIndex,
               TributeCreationDuration = tributecollectionDuration,
               TributeAmount = tributeCollectionAmount,
               OwnerID = owner
           };

            var addShopeTask = firestore.Collection("worlds").Document(neighbourhoodID).Collection("shops").AddAsync(shop);
            yield return new WaitUntil(() => addShopeTask.IsCompleted);

            if (!addShopeTask.IsCompleted)
            {
                Debug.Log("Shop cannot be created, shop number is: " + i);
            }
        }
    }

#endif
}

