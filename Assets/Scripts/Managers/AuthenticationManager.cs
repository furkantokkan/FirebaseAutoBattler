using Hope.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuthenticationManager : MonoSingleton<AuthenticationManager>
{
    public AuthenticationType authenticationType;

    private AuthProvider authProvider;
    private void Start()
    {
        switch (authenticationType)
        {
            case AuthenticationType.Firebase:
                authProvider = gameObject.AddComponent<AuthProviderFirebase>();
                break;
            case AuthenticationType.AWS:
                authProvider = gameObject.AddComponent<AuthProviderAWS>();
                break;
            case AuthenticationType.Azure:
                authProvider = gameObject.AddComponent<AuthProviderAzure>();
                break;
            case AuthenticationType.Custom:
                break;
        }

        if (authProvider != null)
        {
            authProvider.Initialize();
        }
    }

    public AuthProvider GetProvider()
    {
        return authProvider;
    }
}
