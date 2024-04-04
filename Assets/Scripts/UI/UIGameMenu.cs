using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGameMenu : MonoBehaviour
{
    public UIStandart UIStandart;

    public void Logout()
    {
        UIStandart.Confirm("Are you sure?", "Do you want to logout?", "YES", "NO",
            () =>
            {
                AuthenticationManager.instance.GetProvider().Logout();
                UIStandart.Info("Success", "You have successfully logged out!", () => SceneManager.LoadScene("Menu"));
            });
    }
}
