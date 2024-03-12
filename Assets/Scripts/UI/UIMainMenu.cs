using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private UIStandart UIStandart;

    [SerializeField] private GameObject LoginWindow;
    [SerializeField] private GameObject RegisterWindow;

    private void Awake()
    {
    }

    private void Start()
    {
        RegisterWindow.SetActive(false);
        LoginWindow.SetActive(false);

        //if(AuthenticationManager.instance.GetProvider().IsLoggedIn())
        //{
        //    UIStandart.Info("Welcome", "You are already logged in!");
        //}
    }

    public void Register()
    {
        RegisterWindow.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Login()
    {
        LoginWindow.SetActive(true);
        gameObject.SetActive(false);
    }

    public void QuitButtonAction()
    {
        UIStandart.Confirm("Are you sure you want to quit?", "ARE YOU SURE", "YES", "NO", () => Application.Quit());
    }
}
