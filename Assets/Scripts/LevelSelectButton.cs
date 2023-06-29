using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelSelectButton : MonoBehaviour
{
    public string LeveToLoad;

    public GameObject star1, star2, star3;

    void Start()
    {
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);

        /*   if (PlayerPrefs.GetInt(LeveToLoad + "_Star1")==1)
           {
               star1.SetActive(true);
           }

           if (PlayerPrefs.GetInt(LeveToLoad + "_Star2")==1)
           {
               star2.SetActive(true);
           }

           if (PlayerPrefs.GetInt(LeveToLoad + "_Star3")==1)
           {
               star3.SetActive(true);
           }*/
        if (PlayerPrefs.HasKey(LeveToLoad + "_Star1"))
        {
            star1.SetActive(true);
        }

        if (PlayerPrefs.HasKey(LeveToLoad + "_Star2"))
        {
            star2.SetActive(true);
        }

        if (PlayerPrefs.HasKey(LeveToLoad + "_Star3"))
        {
            star3.SetActive(true);
        }


    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(LeveToLoad);
    }

}
