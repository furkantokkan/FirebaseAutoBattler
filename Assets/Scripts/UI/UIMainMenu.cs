using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private UIStandart UIStandart;

    [SerializeField] private GameObject LoginWindow;
    [SerializeField] private GameObject RegisterWindow;
    [SerializeField] private GameObject GenderSelectWindow;
    private void Awake()
    {

    }

    private void Start()
    {
        RegisterWindow.SetActive(false);
        LoginWindow.SetActive(false);
        GenderSelectWindow.gameObject.SetActive(false);
        if (AuthenticationManager.instance.GetProvider().IsRegistered())
        {
            LoginWindow.GetComponent<UILogin>().LoginWithCredentials(
                VariableManager.instance.GetLocalVariable(GameConst.USER_NAME_LOGIN_KEY),
                VariableManager.instance.GetLocalVariable(GameConst.USER_PASSWORD_KEY)
                );
        }
    }

    public void Register()
    {
        RegisterWindow.SetActive(true);
        gameObject.SetActive(false);
        GenderSelectWindow.gameObject.SetActive(false);
    }

    public void Login()
    {
        LoginWindow.SetActive(true);
        gameObject.SetActive(false);
        GenderSelectWindow.gameObject.SetActive(false);
    }

    public void QuitButtonAction()
    {
        UIStandart.Confirm("Are you sure you want to quit?", "ARE YOU SURE", "YES", "NO", () => Application.Quit());
    }
}
