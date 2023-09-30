using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_SceneSelection : MonoBehaviour
{
    public void CupOnTop()
    {
        SceneManager.LoadScene("Tumbler_LevelChoosing");
    }

    public void Marbles()
    {
        SceneManager.LoadScene("Marbles_Menu");
    }
    public void Whack()
    {
        SceneManager.LoadScene("AlienLevelsPage");
    }
    public void Chimp()
    {
        SceneManager.LoadScene("Chimp_MainMenu");
    }
}
