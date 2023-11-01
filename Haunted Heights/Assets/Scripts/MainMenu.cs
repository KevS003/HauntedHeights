using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioPlayer audioStuff;
    //Clips for inputs
    public AudioClip soundEffect;
    public GameObject mainMenu;
    public GameObject gameUI;
    public GameObject optionsMenu;
    public GameObject storeMenu;
    static public bool gameStarted=false;

    private void Start()
    {
        //if statement checking if game was already started
        if(gameStarted == false)
        {
            Time.timeScale = 0f;
            gameUI.SetActive(false);
        }
        else
        {
            PlayGame();
        }

        //go to playgame function immediately 
    }
    public void PlayGame()
    {
        PlaySound(soundEffect);
        Time.timeScale = 1f;
        mainMenu.SetActive(false);
        gameUI.SetActive(true);
        gameStarted = true;
        
    }

    public void Store()
    {
        PlaySound(soundEffect);
        mainMenu.SetActive(false);
        storeMenu.SetActive(true);
    }

    public void Options()
    {
        PlaySound(soundEffect);
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    public void QuitGame()
    {
        PlaySound(soundEffect);
        Application.Quit();
    }

    public void Back()
    {
        PlaySound(soundEffect);
        optionsMenu.SetActive(false);
        storeMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void Pause()
    {
        PlaySound(soundEffect);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        PlaySound(soundEffect);
        Time.timeScale = 1f;
    }


    private void PlaySound(AudioClip sound)
    {
        if(audioStuff !=null)
            audioStuff.PlaySound(sound);
    }
}
