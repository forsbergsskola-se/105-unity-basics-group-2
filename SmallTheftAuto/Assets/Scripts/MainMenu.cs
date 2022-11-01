using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    
    public void OpenMenu()
    {
        mainMenu.SetActive(true);
    }

    public void CloseMenu()
    {
        mainMenu.SetActive(false);
    }
}