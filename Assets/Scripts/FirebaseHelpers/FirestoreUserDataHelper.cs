
using Firebase.Firestore;
using System;

[FirestoreData]
public class FirestoreUserDataHelper
{
    [FirestoreProperty]
    public string userID { get; set; }
    [FirestoreProperty]
    public string nickName { get; set; }
    [FirestoreProperty]
    public long money { get; set; }
    [FirestoreProperty]
    public int gender { get; set; }
    [FirestoreProperty]
    public int level { get; set; }
    [FirestoreProperty]
    public DateTime welcomePrizeCollectedAt { get; set; }

    [FirestoreProperty]
    public DateTime userCreatedAt { get; set; }

    [FirestoreProperty]
    public int experience { get; set; }
}
