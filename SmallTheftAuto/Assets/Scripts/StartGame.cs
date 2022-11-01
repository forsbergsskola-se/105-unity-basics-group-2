using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject MainMenu;
    public void LoadGame()
    {
        SceneManager.LoadScene("SanAndreas");
    }

    public void CloseGame()
    {
        MainMenu.SetActive(false);
    }

    public void OpenGame()
    {
        MainMenu.SetActive(true);
    }
}
