using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIRegisterGenderSelect : MonoBehaviour
{
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

        UserManager.instance.CreateUser(authID, TglMale.isOn ? GenderType.Man : GenderType.Female, nickName.text.Trim(),
            (result, param) =>
            {
                if (result)
                {
                    Debug.Log("Registered!");
                    UIStandart.Info("Success", "You have successfully registered!");
                }
                else
                {
                    Debug.LogError("Error: " + param);
                }

                UIStandart.HideLoading();
            });
    }
}
