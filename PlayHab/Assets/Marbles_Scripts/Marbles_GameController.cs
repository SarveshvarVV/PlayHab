
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Marbles_GameController : MonoBehaviour
{
    public static Marbles_GameController instance;

    public GameObject GamePanel;
    public GameObject PausePanel;

    private Vector2 originalPosition;
    
    int randomiser;
    public List<GameObject> neweggs;
    public List<int> pattern;

    int i;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    private void Start()
    {
        if (Marbles_MenuController.instance1.hard == false)
        {
            StartCoroutine(WaitingTime());
        }
        else if(Marbles_MenuController.instance1.hard==true)
        {
            StartCoroutine(WaitingTimeH());
        }
    }
    IEnumerator WaitingTime()
    {
        //Debug.Log("coroutine");
        yield return new WaitForSeconds(3f);
        for (i = 0; i < Marbles_MenuController.instance1.levelnum; i++)
        {
            randomiser = Random.Range(0, neweggs.Count);
            //Debug.Log(randomiser);
            pattern.Add(randomiser);
            yield return new WaitForSeconds(3f);
            Instantiate(neweggs[randomiser], originalPosition, Quaternion.identity);
        }

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Marbles_Check");


     }
    IEnumerator WaitingTimeH()
    {
        //Debug.Log("coroutine");
        yield return new WaitForSeconds(3f);
        for (i = 0; i < Marbles_MenuController.instance1.levelnum; i++)
        {
            randomiser = Random.Range(0, neweggs.Count);
            //Debug.Log(randomiser);
            pattern.Add(randomiser);
            yield return new WaitForSeconds(1.5f);
            Instantiate(neweggs[randomiser], originalPosition, Quaternion.identity);
        }

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Marbles_Check");


    }
    public void Pause()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
        GamePanel.SetActive(false);
    }
    public void Resume()
    {
        PausePanel.SetActive(false);
        GamePanel.SetActive(true);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        GameObject[] gos2 = GameObject.FindGameObjectsWithTag("PoNeePo");
        foreach (GameObject go2 in gos2)
            Destroy(go2);

        PausePanel.SetActive(false);
        GamePanel.SetActive(true);
        Time.timeScale = 1;
        SceneManager.LoadScene("Marbles_Show");    
    }
    public void LevelSelect()
    {
        GameObject[] gos2 = GameObject.FindGameObjectsWithTag("PoNeePo");
        foreach (GameObject go2 in gos2)
            Destroy(go2);

        GameObject[] gos = GameObject.FindGameObjectsWithTag("Goofy");
        foreach (GameObject go in gos)
            Destroy(go);

        Time.timeScale = 1;

        SceneManager.LoadScene("Marbles_Menu");
    }
    

}
