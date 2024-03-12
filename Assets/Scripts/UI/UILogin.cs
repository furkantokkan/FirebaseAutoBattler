using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UILogin : MonoBehaviour
{
    public UIStandart UIStandart;
    public GameObject MainMenu;

    public TMP_InputField InputUserName;
    public TMP_InputField InputPassword;

    public void ReturnToMenu()
    {
        MainMenu.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void PerformLogin()
    {
        if (!CheckInputIsValid())
        {
            return;
        }

        UIStandart.ShowLoading("Logging in", "Please wait...");
    }

    private bool CheckInputIsValid()
    {
        if (string.IsNullOrEmpty(InputUserName.text.Trim()) && string.IsNullOrEmpty(InputPassword.text.Trim()))
        {
            UIStandart.Error("Error", "Please enter your username and password!");
            return false;
        }
        else if (string.IsNullOrEmpty(InputUserName.text.Trim()))
        {
            UIStandart.Error("Error", "Please enter your username!");
            return false;
        }
        else if (string.IsNullOrEmpty(InputPassword.text.Trim()))
        {
            UIStandart.Error("Error", "Please enter your password!");
            return false;
        }

        return true;
    }
}
