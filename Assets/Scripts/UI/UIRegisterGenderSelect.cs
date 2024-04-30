using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIRegisterGenderSelect : MonoBehaviour
{
    public UILogin LoginWindow;
    public UIStandart UIStandart;
    public TMP_InputField nickName;
    public Toggle TglMale;

    private string authID;

    public void Show(string authID)
    {
        this.authID = authID;
        gameObject.SetActive(true);
    }

    public void Hidde()
    {
        gameObject.SetActive(false);
    }

    public void Next()
    {
        if (string.IsNullOrEmpty(nickName.text.Trim()))
        {
            UIStandart.Error("Error", "Please enter your nickname!");
            return;
        }

        UIStandart.ShowLoading("Registering", "Please wait...");

        UserManager.instance.CreateUser(authID, TglMale.isOn ? NationaltyType.English : NationaltyType.Poland, nickName.text.Trim(),
            (result, param) =>
            {
                if (result)
                {
                    UIStandart.ShowLoading("Logging in", "Please wait...");
                    LoginWindow.LoginWithCredentials(VariableManager.instance.GetLocalVariable(GameConst.USER_NAME_LOGIN_KEY),
                        VariableManager.instance.GetLocalVariable(GameConst.USER_PASSWORD_KEY));
                }
                else
                {
                    UIStandart.Error("Error", param);
                    Debug.LogError("Error: " + param);
                }

                UIStandart.HideLoading();
            });
    }
}
