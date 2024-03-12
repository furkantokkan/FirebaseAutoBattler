using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AuthProvider : MonoBehaviour
{
    public Action<bool, string> OnLogin = null;
    public Action<bool, string> OnRegister = null;

    public abstract string Vendor();

    public abstract void Initialize(string[] args = null);

    public abstract bool IsLoggedIn();
    public abstract void Login(string userName, string password, Action<bool, string> onComplete);

    public abstract void Logout();

    public abstract void Register(string userName, string password, Action<bool, string> onComplete);
}
