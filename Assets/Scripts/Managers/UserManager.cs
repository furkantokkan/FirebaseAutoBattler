using Hope.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserManager : MonoSingleton<UserManager>
{
    public void CreateUser(string authID,NationaltyType gender, string nickName, Action<bool, string> onComplete)
    {
        DataManager.instance.GetProvider().CreateUser(authID, gender, nickName, onComplete);
    }

    public void GetUser(string userID, Action<DOUserHelper> onComplete)
    {
        DataManager.instance.GetProvider().GetUser(userID, onComplete);
    }
}
 