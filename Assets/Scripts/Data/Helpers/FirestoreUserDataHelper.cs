
using Firebase.Firestore;
using System;

[FirestoreData]
public class FirestoreUserDataHelper
{
    [FirestoreProperty]
    public string UserID { get; set; }
    [FirestoreProperty]
    public string NickName { get; set; }
    [FirestoreProperty]
    public long Money { get; set; }
    [FirestoreProperty]
    public int Gender { get; set; }
    [FirestoreProperty]
    public int Level { get; set; }
    [FirestoreProperty]
    public DateTime WelcomePrizeCollectedAt { get; set; }

    [FirestoreProperty]
    public DateTime UserCreatedAt { get; set; }

    [FirestoreProperty]
    public int Experience { get; set; }

    [FirestoreProperty]
    public string NeighborhoodID { get; set; }
}
