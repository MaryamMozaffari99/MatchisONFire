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

    }
    public void ShuffelBoard()
    {

    }
    public void QuitGame()
    {

    }

    public void GoTOLevelSelect()
    {

    }

    public void TryAgain()
    {

    }

}
