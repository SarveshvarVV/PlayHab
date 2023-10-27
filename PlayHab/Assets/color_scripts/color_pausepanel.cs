using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class color_pausepanel : MonoBehaviour
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
        SceneManager.LoadScene("CatColor_LevelSel");

    }
    public void Restart_1()
    {
        SceneManager.LoadScene("Color_level1"); 
       
    }
    public void Restart_2()
    {
        SceneManager.LoadScene("Color_level2");

    }
    public void Restart_3()
    {
        SceneManager.LoadScene("Color_level3");

    }
    public void Restart_4()
    {
        SceneManager.LoadScene("Color_level4");

    }
    public void Restart_5()
    {
        SceneManager.LoadScene("Color_level5");

    }
    public void Restart_QA()
    {
        SceneManager.LoadScene("Color_qn");

    }
}
