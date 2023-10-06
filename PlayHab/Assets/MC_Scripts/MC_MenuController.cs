using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MC_MenuController : MonoBehaviour
{
    public static MC_MenuController instance;

    public int choice;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    public void MainScreen()
    {
        SceneManager.LoadScene("MainScreen");
    }
    public void Lvl1()
    {
         choice= 1;
        SceneManager.LoadScene("MC_Scatter");
    }
    public void Lvl2()
    {
        choice= 2;
        SceneManager.LoadScene("MC_Scatter");
    }
    public void Lvl3()
    {
        choice= 3;
        SceneManager.LoadScene("MC_Scatter");
    }
    public void Lvl4()
    {
        choice= 4;
        SceneManager.LoadScene("MC_Scatter");
    }
    public void Lvl5()
    {
        choice= 5;
        SceneManager.LoadScene("MC_Scatter");
    }
    public void Lvl6()
    {
        choice= 6;
        SceneManager.LoadScene("MC_Scatter");
    }
}
