using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public string LevelToload;



    public void StartGame()
    {
        SceneManager.LoadScene(LevelToload);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
 