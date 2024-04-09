using Firebase.Firestore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[FirestoreData]
public class FirestoreNeighbourhoodData
{
    [FirestoreProperty]
    public string OwnerID { get; set; }

    [FirestoreProperty]
    public string ownerName { get; set; }

    [FirestoreProperty]
    public string neighbourhoodName { get; set; }

    [FirestoreProperty]
    public string worldID { get; set; }

    [FirestoreProperty]
    public int x { get; set; }

    [FirestoreProperty]
    public int y { get; set; }
}
