using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameisPaused = false;

    public GameObject screen;
    public GameObject gameUI;
    private void Start()
    {
        Time.timeScale = 0f;
        screen.SetActive(true);
        gameUI.SetActive(false);
    }
    public void PlayGame()
    {
        Time.timeScale = 1f;
        screen.SetActive(false);
        gameUI.SetActive(true);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
