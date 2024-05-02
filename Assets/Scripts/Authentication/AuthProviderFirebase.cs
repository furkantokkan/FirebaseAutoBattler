using DG.Tweening;
using Firebase;
using Firebase.Auth;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AuthProviderFirebase : AuthProvider
{
    FirebaseAuth auth;

    bool isInitialized = false;
    public override void Initialize(string[] args)
    {
        auth = FirebaseAuth.DefaultInstance;
        Debug.Log("Firebase Auth Initialized");

        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                //   app = Firebase.FirebaseApp.DefaultInstance;

                // Set a flag here to indicate whether Firebase is ready to use by your app.
                isInitialized = true;
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                                     "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });
    }

    public override bool IsRegistered()
    {
        return VariableManager.instance.LocalVariableExists(GameConst.USER_NAME_LOGIN_KEY) && VariableManager.instance.LocalVariableExists(GameConst.USER_PASSWORD_KEY);
    }

    public override void Login(string userName, string password, Action<bool, string> onComplete)
    {
        if (!isInitialized) return;
        StartCoroutine(LoginBG(userName, password, onComplete));
    }

    public override void Logout()
    {
        auth.SignOut();

        Debug.Log("Logged out");

        VariableManager.instance.DeleteLocalVariable(GameConst.USER_NAME_LOGIN_KEY);
        VariableManager.instance.DeleteLocalVariable(GameConst.USER_PASSWORD_KEY);
    }

    public override void Register(string userName, string password, Action<bool, string> onComplete)
    {
        if (!isInitialized) return;
        StartCoroutine(RegisterBG(userName, password, onComplete));
    }

    public override string Vendor()
    {
        throw new System.NotImplementedException();
    }

    private IEnumerator LoginBG(string userName, string password, Action<bool, string> onComplete)
    {
        var loginTask = auth.SignInWithEmailAndPasswordAsync(userName, password);

        yield return new WaitUntil(() => loginTask.IsCompleted);

        if (loginTask.Exception != null)
        {
            FirebaseException firebaseException = loginTask.Exception.GetBaseException() as FirebaseException;
            AuthError errorCode = (AuthError)firebaseException.ErrorCode;

            string message;
            switch (errorCode)
            {
                case AuthError.WrongPassword:
                    message = "Wrong Password";
                    Debug.LogWarning("Wrong Password");
                    break;
                case AuthError.UserNotFound:
                    message = "User not found";
                    Debug.LogWarning("User not found");
                    break;
                default:
                    message = "Error Code: " + errorCode.ToString();
                    Debug.LogWarning(message);
                    break;
            }

            onComplete?.Invoke(false, message);
        }
        else
        {
            Debug.Log("Logged in");

            onComplete?.Invoke(true, loginTask.Result.User.UserId);
        }
    }

    private IEnumerator RegisterBG(string userName, string password, Action<bool, string> onComplete)
    {
        var registerTask = auth.CreateUserWithEmailAndPasswordAsync(userName, password);

        yield return new WaitUntil(() => registerTask.IsCompleted);

        if (registerTask.Exception != null)
        {
            FirebaseException firebaseException = registerTask.Exception.GetBaseException() as FirebaseException;
            AuthError errorCode = (AuthError)firebaseException.ErrorCode;

            string message;
            switch (errorCode)
            {
                case AuthError.EmailAlreadyInUse:
                    message = "E-mail adress is already in use. Please try another one.";
                    Debug.LogWarning("E-mail already in use");
                    break;
                case AuthError.InvalidEmail:
                    message = "Invalid E-mail adress. Please try another one.";
                    Debug.LogWarning("Invalid Email");
                    break;
                case AuthError.WeakPassword:
                    Debug.LogWarning("Weak Password");
                    message = "Password is too weak. Please try another one.";
                    break;
                default:
                    message = "Error Code: " + errorCode.ToString();
                    Debug.LogWarning(message);
                    break;
            }

            onComplete?.Invoke(false, message);
        }
        else
        {
            Debug.Log("Registered");
            onComplete?.Invoke(true, registerTask.Result.User.UserId);
        }
    }
}
