using Firebase.Firestore;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataProviderFirebase : DataProvider
{
    FirebaseFirestore firestore;

    public override void CreateUser(string id, NationaltyType nationalty, string nickName, Action<bool, string> onComplete)
    {
        StartCoroutine(CreateUserBackGround(id, nationalty, nickName, onComplete));
    }

    private IEnumerator CreateUserBackGround(string id, NationaltyType nationalty, string nickName, Action<bool, string> onComplete)
    {
        //find an empty place for a user
        var findEmptySpaceTask = firestore.Collection("worlds").WhereEqualTo("OwnerID", "").GetSnapshotAsync();
        yield return new WaitUntil(() => findEmptySpaceTask.IsCompleted);

        if (findEmptySpaceTask.IsFaulted)
        {
            onComplete?.Invoke(false, "There is no remaining space");
            yield break;
        }

        string availableNegiborhoodID = "N/A";
        foreach (var item in findEmptySpaceTask.Result.Documents)
        {
            availableNegiborhoodID = item.Id;
            break;
        }

        if (availableNegiborhoodID == "N/A")
        {
            onComplete?.Invoke(false, "There is no space remaining");
            yield break;
        }

        //create a user
        var newUser = new FirestoreUserDataHelper()
        {
            Gender = (int)nationalty,
            Level = 1,
            Money = SettingsManager.instance.WelcomePrize,
            NickName = nickName,
            UserID = id,
            // TODO: Collet fime from a time manager instead of device time
            WelcomePrizeCollectedAt = DateTime.Now,
            UserCreatedAt = DateTime.Now,
            Experience = 0,
            NeighborhoodID = availableNegiborhoodID
        };

        var addUserTask = firestore.Collection("Users").AddAsync(newUser);
        yield return new WaitUntil(() => addUserTask.IsCompleted);

        if (addUserTask.IsFaulted)
        {
            onComplete?.Invoke(false, "An Error Occured");
            yield break;
        }

        string addedUserId = addUserTask.Result.Id;

        //update land owner
        var updates = new Dictionary<FieldPath, object>()
        {
            {new FieldPath("OwnerID"), addedUserId },
            {new FieldPath("OwnerName"), nickName }
        };
        var updateUserTask = firestore.Collection("worlds").Document(availableNegiborhoodID).UpdateAsync(updates);
        yield return new WaitUntil(() => updateUserTask.IsCompleted);

        if (updateUserTask.IsFaulted)
        {
            onComplete?.Invoke(false, "User has not able to update");
            yield break;
        }


        onComplete?.Invoke(true, addedUserId);
    }

    public override void GetUser(string id, Action<DOUserHelper> onComplete)
    {
        StartCoroutine(GetUserBackGround(id, onComplete));
    }

    private IEnumerator GetUserBackGround(string id, Action<DOUserHelper> onComplete)
    {
        var getUserTask = firestore.Collection("Users").WhereEqualTo("userID", id).GetSnapshotAsync();
        yield return new WaitUntil(() => getUserTask.IsCompleted);

        if (getUserTask.IsFaulted)
        {
            onComplete(null);
            yield break;
        }

        if (getUserTask.Result.Count <= 0)
        {
            onComplete(null);
            yield break;
        }

        foreach (var item in getUserTask.Result.Documents)
        {
            var data = item.ToDictionary();

            onComplete(new DOUserHelper()
            {
                Gender = int.Parse(data["gender"].ToString()),
                Level = int.Parse(data["level"].ToString()),
                Money =  long.Parse(data["money"].ToString()),
                UserName = data["nickName"].ToString(),
                Experience = int.Parse(data["experience"].ToString())
            });

            break;
        }
    }

    public override string GetVendor()
    {
        throw new NotImplementedException();
    }

    public override void Initialize(string[] args, Action<bool> onComplete)
    {
        firestore = FirebaseFirestore.DefaultInstance;
        onComplete?.Invoke(true);
    }

    //public override void SetGender(string id, GenderType gender, Action onComplete)
    //{
    //    throw new NotImplementedException();
    //}

    public override void SetUserNickame(string id, string nickName, Action onComplete)
    {
        throw new NotImplementedException();
    }

    public override void UpdateUsersFirstEntryDateAndTime()
    {
        throw new NotImplementedException();
    }
}
