using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class __Pause__Alien : MonoBehaviour
{

    public GameObject PausePanel;


    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("AlienLevelsPage");

    }
    public void Lvl1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("AlienLevel_1");
        Debug.Log("sceneswitch");
    }

    public void Lvl2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("AlienLevel_2");
        Debug.Log("sceneswitch");
    }

    public void Lvl3()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("AlienLevel_3");
        Debug.Log("sceneswitch");
    }

    public void Lvl4()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("AlienLevel_4");
        Debug.Log("sceneswitch");
    }

    public void Lvl5()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("AlienLevel_5");
        Debug.Log("sceneswitch");
    }

    public void Lvl6()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("AlienLevel_6");
        Debug.Log("sceneswitch");
    }

    public void Lvl7()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("AlienLevel_7");
        Debug.Log("sceneswitch");
    }

    public void Lvl8()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("AlienLevel_8");
        Debug.Log("sceneswitch");
    }

    public void Lvl9()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("AlienLevel_9");
        Debug.Log("sceneswitch");
    }

    public void Lvl10()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("AlienLevel_10");
        Debug.Log("sceneswitch");
    }
    public void Restart_1()
    {
        SceneManager.LoadScene("AlienLevel_1");

    }
    public void Restart_2()
    {
        SceneManager.LoadScene("AlienLevel_2");

    }
    public void Restart_3()
    {
        SceneManager.LoadScene("AlienLevel_3");

    }
    public void Restart_4()
    {
        SceneManager.LoadScene("AlienLevel_4");

    }
    public void Restart_5()
    {
        SceneManager.LoadScene("AlienLevel_5");

    }
    public void Restart_6()
    {
        SceneManager.LoadScene("AlienLevel_6");

    }
    public void Restart_7()
    {
        SceneManager.LoadScene("AlienLevel_7");

    }
    public void Restart_8()
    {
        SceneManager.LoadScene("AlienLevel_8");

    }
    public void Restart_9()
    {
        SceneManager.LoadScene("AlienLevel_9");

    }
    public void Restart_10()
    {
        SceneManager.LoadScene("AlienLevel_10");

    }

    public void Level_page()
    {

        SceneManager.LoadScene("AlienLevelsPage");
        Debug.Log("sceneswitch");
    }
}