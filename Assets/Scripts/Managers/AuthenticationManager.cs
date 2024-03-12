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
                authProvider = GetComponent<AuthProviderFirebase>();
                break;
            case AuthenticationType.Aws:
                authProvider = GetComponent<AuthProviderAWS>();
                break;
            case AuthenticationType.Playfab:
                authProvider = GetComponent<AuthProviderPlayfab>();
                break;
            case AuthenticationType.Custom:
                break;
        }

        if (authProvider != null)
        {
            authProvider.Initialize();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            authProvider.Register("test@gmail.com", "12345678");
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            if (authProvider.IsLoggedIn())
            {
                authProvider.Logout(); 
            }
            else
            {
                authProvider.Login("test@gmail.com", "12345678");
            }
        }
    }

    public AuthProvider GetAuthProvider()
    {
        return authProvider;
    }
}
