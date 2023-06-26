using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TMP_Text timeText;
    public TMP_Text scoreText;

    public TMP_Text winScore;
    public TMP_Text winText;
    public GameObject winStars1, winStars2, winStars3 ;


    public GameObject roundOverScreen;

    private Board theboard;

    public string LevelSelect;

    public GameObject pauseScreen;

    private void Awake()
    {
        theboard = FindObjectOfType<Board>();
    }

    void Start()
    {
        winStars1.SetActive(false);
        winStars2.SetActive(false);
        winStars3.SetActive(false);
    }
    void Update()
    {
        
    }

    public void PauseUnPause()
    {
        if (!pauseScreen.activeInHierarchy)
        {
            pauseScreen.SetActive(true);

            Time.timeScale = 0f;
        }
        else
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    public void ShuffelBoard()
    {
        theboard.ShuffleBoard();
    }
    public void QuitGame()
    {
        Application.Quit(0);
    }

    public void GoTOLevelSelect()
    {
        SceneManager.LoadScene(LevelSelect);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
