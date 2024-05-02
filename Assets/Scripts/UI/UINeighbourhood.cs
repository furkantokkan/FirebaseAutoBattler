using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UINeighbourhood : MonoBehaviour
{
    public UIGameMenu UIGameMenu;

    public void HideWindow()
    {
        UIGameMenu.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
