using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataProviderMySQL : DataProvider
{
    public override void CreateUser(string id, GenderType gender, string nickName, Action<bool, string> onComplete)
    {
        throw new NotImplementedException();
    }

    public override void GetUser(string id, Action<DOUserHelper> onComplete)
    {
        throw new NotImplementedException();
    }

    public override string GetVendor()
    {
        throw new NotImplementedException();
    }

    public override void Initialize(string[] args, Action<bool> onComplete)
    {
        throw new NotImplementedException();
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
