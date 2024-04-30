using Firebase.Firestore;
using System;

[FirestoreData]
public class FirestoreNeighbourhoodShopData 
{
    [FirestoreProperty]
    public string OwnerID { get; set; }

    [FirestoreProperty]
    public ShopeType ShopType { get; set; }

    [FirestoreProperty]
    public int AvatarIndex { get; set; }

    [FirestoreProperty]
    public int TributeCreationDuration { get; set; }

    [FirestoreProperty]
    public int TributeAmount { get; set; }



}
