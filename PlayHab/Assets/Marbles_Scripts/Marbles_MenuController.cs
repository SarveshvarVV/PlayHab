using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Marbles_MenuController : MonoBehaviour
{
    public static Marbles_MenuController instance1;
    public GameObject levelPanel;
    public GameObject menu;
    public  int levelnum;
    public bool hard;

    
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance1 == null)
        {
            instance1 = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    public void StartGame()
    {
        menu.SetActive(false);
        levelPanel.SetActive(true); 
        
    }
    public void BacktoMenu()
    {
      levelPanel.SetActive(false);  
      menu.SetActive(true);
    }
    public void Lvl1()
    {
        levelnum = 3;
        hard= false;
        SceneManager.LoadScene("Marbles_Show");
        
    }
    public void Lvl2()
    {
        levelnum = 3;
        hard = true;
        SceneManager.LoadScene("Marbles_Show");
    }
    public void Lvl3()
    {
        levelnum = 4;
        hard = false;
        SceneManager.LoadScene("Marbles_Show");
    }
    public void Lvl4()
    {
        levelnum = 4;
        hard = true;
        SceneManager.LoadScene("Marbles_Show");
    }
    public void Lvl5()
    {
        levelnum = 5;
        hard = false;
        SceneManager.LoadScene("Marbles_Show");
    }
    public void Lvl6()
    {
        levelnum = 5;
        hard = true;
        SceneManager.LoadScene("Marbles_Show");

    }
    public void Lvl7()
    {
        levelnum = 6;
        hard = false;
        SceneManager.LoadScene("Marbles_Show");
    }
    public void Lvl8()
    {
        levelnum = 6;
        hard = true;
        SceneManager.LoadScene("Marbles_Show");
    }
    public void Lvl9()
    {
        levelnum = 7;
        hard = false;
        SceneManager.LoadScene("Marbles_Show");
    }
    public void Lvl10()
    {
        levelnum = 7;
        hard = true;
        SceneManager.LoadScene("Marbles_Show");
    }
}
