using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject mainMenu;
    public GameObject gameUI;
    public GameObject optionsMenu;
    public GameObject storeMenu;
    private void Start()
    {
        Time.timeScale = 0f;
        gameUI.SetActive(false);
    }
    public void PlayGame()
    {
        Time.timeScale = 1f;
        mainMenu.SetActive(false);
        gameUI.SetActive(true);
        
    }

    public void Store()
    {
        mainMenu.SetActive(false);
        storeMenu.SetActive(true);
    }

    public void Options()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Back()
    {
        optionsMenu.SetActive(false);
        storeMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
