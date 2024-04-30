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
    public string OwnerName { get; set; }

    [FirestoreProperty]
    public string NeighbourhoodName { get; set; }

    [FirestoreProperty]
    public string WorldID { get; set; }

    [FirestoreProperty]
    public int X { get; set; }

    [FirestoreProperty]
    public int Y { get; set; }
}
