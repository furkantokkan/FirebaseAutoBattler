using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIRegister : MonoBehaviour
{
    public UIStandart UIStandart;
    public GameObject MainMenu;

    public TMP_InputField InputUserName;
    public TMP_InputField InputPassword;
    public TMP_InputField InputPasswordRetype;


    public void ReturnToMenu()
    {
        MainMenu.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void PerformRegister()
    {
        if (!CheckInputIsValid())
        {
            return;
        }

        UIStandart.ShowLoading("Registering", "Please wait...");

        AuthenticationManager.instance.GetProvider().Register(InputUserName.text.Trim(), InputPassword.text.Trim(), (result, message) =>
        {
            UIStandart.HideLoading();

            if (result)
            {
                UIStandart.Info("Success", "You have successfully registered!");
            }
            else
            {
                UIStandart.Error("Error", message);
            }
        });
    }

    private bool CheckInputIsValid()
    {
        if (string.IsNullOrEmpty(InputUserName.text.Trim()) && string.IsNullOrEmpty(InputPassword.text.Trim()) && string.IsNullOrEmpty(InputPasswordRetype.text.Trim()))
        {
            UIStandart.Error("Error", "Please enter your username, password and retype your password!");
            return false;
        }
        else if (string.IsNullOrEmpty(InputUserName.text.Trim()) && string.IsNullOrEmpty(InputPassword.text.Trim()))
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
        else if (InputPassword.text.Trim().Length < 8)
        {
            UIStandart.Error("Error", "Password must be at least 8 characters long!");
            return false;
        }
        else if (string.IsNullOrEmpty(InputPasswordRetype.text.Trim()))
        {
            UIStandart.Error("Error", "Please retype your password!");
            return false;
        }
        else if (InputPassword.text.Trim() != InputPasswordRetype.text.Trim())
        {
            UIStandart.Error("Error", "Passwords do not match!");
            return false;
        }

        return true;
    }
}
