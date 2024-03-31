using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DataProvider : MonoBehaviour
{
    public abstract void Initialize(string[] args = null, Action<bool> onComplete = null);

    public abstract void CreateUser(string id, GenderType gender, string nickName, Action<bool, string> onComplete);

    public abstract void GetUser(string id, Action<DOUserHelper> onComplete);

    public abstract void SetUserNickame(string id, string nickName, Action onComplete);

    //public abstract void SetGender(string id, GenderType gender, Action onComplete); 

    public abstract void UpdateUsersFirstEntryDateAndTime();

    public abstract string GetVendor();
}
