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
        var newUser = new FirestoreUserDataHelper()
        {
            gender = (int)nationalty,
            level = 1,
            money = SettingsManager.instance.WelcomePrize,
            nickName = nickName,
            userID = id,
            // TODO: Collet fime from a time manager instead of device time
            welcomePrizeCollectedAt = DateTime.Now,
            userCreatedAt = DateTime.Now,
            experience = 0
        };

        var addUserTask = firestore.Collection("Users").AddAsync(newUser);
        yield return new WaitUntil(() => addUserTask.IsCompleted);

        if (addUserTask.IsFaulted)
        {
            onComplete?.Invoke(false, "An Error Occured");
            yield break;
        }

        string addedUserId = addUserTask.Result.Id;
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
