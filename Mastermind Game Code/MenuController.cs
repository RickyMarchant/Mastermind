//Created by Ricky Marchant.
//MASTERMIND
//11.14.2017
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    //public static MenuController _instance;
    public Toggle[] backgroundToggles;
    public GameObject go1;
    public GameObject go2;
    public GameObject go3;
    public Toggle[] musicToggles;
    public GameObject go4;
    public GameObject go5;
    public GameObject go6;

    private static bool isMusicMuted = false;

    public void Start()
    {
        go1.SetActive(false);
        go2.SetActive(true);
        go3.SetActive(false);

        go4.SetActive(true);
        go5.SetActive(false);
        go6.SetActive(false);       
}

    public void loadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

        //don't destroy backgrounds on loading play level.
        DontDestroyOnLoad(go1);
        DontDestroyOnLoad(go2);
        DontDestroyOnLoad(go3);
        DontDestroyOnLoad(go4);
        DontDestroyOnLoad(go5);
        DontDestroyOnLoad(go6);
        DontDestroyOnLoad(this);
    }
    

    public void quitGame()
    {
        Application.Quit();
    }
    //select background. Make only one option possible. Set others to false.
    public void setBackground(int i)
    {
        if (backgroundToggles[0].isOn )
        {
            if (isMusicMuted == false)
            {
                go1.SetActive(true);
                go2.SetActive(false);
                go3.SetActive(false);
            }
        }

        if (backgroundToggles[1].isOn)
        {
            if (isMusicMuted == false)
            {
                go1.SetActive(false);
                go2.SetActive(true);
                go3.SetActive(false);
            }
                
        }
        if (backgroundToggles[2].isOn)
        {
            go1.SetActive(false);
            go2.SetActive(false);
            go3.SetActive(true);
        }
    }
    public void setMusic(int i)
    {
        if (musicToggles[0].isOn)
        {
            go4.SetActive(true);
            go5.SetActive(false);
            go6.SetActive(false);
        }
        if (musicToggles[1].isOn)
        {
            go4.SetActive(false);
            go5.SetActive(true);
            go6.SetActive(false);
        }
        if (musicToggles[2].isOn)
        {
            go4.SetActive(false);
            go5.SetActive(false);
            go6.SetActive(true);
        }
        if (musicToggles[3].isOn)
        {
            go4.SetActive(false);
            go5.SetActive(false);
            go6.SetActive(false);
        }
    }
}
