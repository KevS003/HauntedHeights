using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(0);
        }*/

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void RestartChristmas()
    {
        SceneManager.LoadScene("HolidayScene");
    }
    public void EnterRevenge()
    {
        SceneManager.LoadScene(2);
    }    
}
