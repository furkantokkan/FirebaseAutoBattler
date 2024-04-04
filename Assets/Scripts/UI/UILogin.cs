using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILogin : MonoBehaviour
{
    public UIStandart UIStandart;
    public UIRegisterGenderSelect genderSelect;

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

        LoginWithCredentials(InputUserName.text.Trim(), InputPassword.text.Trim());
    }

    public void LoginWithCredentials(string userName, string password)
    {
        UIStandart.ShowLoading("Logging in", "Please wait...");

        AuthenticationManager.instance.GetProvider().Login(userName, password, (result, userID) =>
        {
            if (result)
            {
                VariableManager.instance.AddLocalVariable(GameConst.USER_NAME_LOGIN_KEY, userName);
                VariableManager.instance.AddLocalVariable(GameConst.USER_PASSWORD_KEY, password);

                UserManager.instance.GetUser(userID, (param) =>
                {
                    if (param == null)
                    {
                        // TODO: Display gender and nick name screen
                        genderSelect.Show(userID);
                        UIStandart.HideLoading();
                    }
                    else
                    {
                        //TODO: go to next scene
                        Debug.Log("Go To The Main Menu");
                        DOVirtual.DelayedCall(1f, () =>
                        {
                            SceneManager.LoadScene("Game");
                        });
                    }
                });
            }
            else
            {
                UIStandart.HideLoading();
                UIStandart.Error("Error", userID);
            }
        });
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
