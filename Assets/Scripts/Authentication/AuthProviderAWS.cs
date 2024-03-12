using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuthProviderAWS : AuthProvider
{
    public override void Initialize(string[] args)
    {
        Debug.Log("Aws is Initialized");
    }

    public override bool IsLoggedIn()
    {
        throw new System.NotImplementedException();
    }

    public override void Login(string userName, string password)
    {
        throw new System.NotImplementedException();
    }

    public override void Logout()
    {
        throw new System.NotImplementedException();
    }

    public override void Register(string userName, string password)
    {
        throw new System.NotImplementedException();
    }

    public override string Vendor()
    {
        throw new System.NotImplementedException();
    }
}
