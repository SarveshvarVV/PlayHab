using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MC_LevelController : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public GameObject panel5;
    public GameObject panel6;

    public GameObject PauseMenu;
    public GameObject PauseButton;
    // Start is called before the first frame update
    void Start()
    {
        if (MC_MenuController.instance.choice == 1)
        {
            panel1.SetActive(true);
        }
        else if (MC_MenuController.instance.choice == 2)
        {
            panel2.SetActive(true);
        }
        else if (MC_MenuController.instance.choice == 3)
        {
            panel3.SetActive(true);
        }
        else if (MC_MenuController.instance.choice == 4)
        {
            panel4.SetActive(true);
        }
        else if (MC_MenuController.instance.choice == 5)
        {
            panel5.SetActive(true);
        }
        else if (MC_MenuController.instance.choice == 6)
        {
            panel6.SetActive(true);
        }
    }
    public void Pause()
    {
        PauseButton.SetActive(false);
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void Resume1()
    {
        PauseButton.SetActive(true);
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        
    }
    public void Restart()
    {
        PauseButton.SetActive(true);
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("MC_Scatter");
    }
    public void levelselect()
    {
        PauseButton.SetActive(true);
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Ratioed");
        foreach (GameObject go in gos)
            Destroy(go);
        SceneManager.LoadScene("MC_Menu");
    }


}
