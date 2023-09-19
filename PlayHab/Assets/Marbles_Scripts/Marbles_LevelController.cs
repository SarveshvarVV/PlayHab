
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Marbles_LevelController : MonoBehaviour
{
    public GameObject GamePanel;
    public GameObject PausePanel;

    public GameObject GamePanel2;
    public GameObject PausePanel2;
    public Marbles_MenuController mc;
    public Marbles_GameController gc;

    public GameObject yesno;
    public GameObject correctPanel;
    public GameObject wrongPanel;

    public Text timetextcorr;
    public Text timetextwrong;

    public float timer = 0;
    public List<int> pt;
    int randomcorrect;

    public List<GameObject> eggs;

    public Transform[] pos3;
    public Transform[] pos4;
    public Transform[] pos5;
    public Transform[] pos6;
    public Transform[] pos7;

    public int randomegg;
    int i;

    public bool yaww;
    public bool isyesno;

    private void Start()
    {
        for (i = 0; i < Marbles_MenuController.instance1.levelnum; i++)
        {
            pt.Add(Marbles_GameController.instance.pattern[i]);

        }
        StartCoroutine(Delays());

        
    }
    private void Update()
    {
        if (isyesno)
        {
            timer += Time.deltaTime * 1f;
            //Debug.Log(timer);
        }
    }
    IEnumerator Delays()
    {
        randomcorrect = Random.Range(0, 2);
        if (randomcorrect == 0)
        {
            yaww = false;
            if (Marbles_MenuController.instance1.levelnum == 4)
            {
                for (i = 0; i < 4; i++)
                {
                    randomegg = Random.Range(0, eggs.Count);


                    Instantiate(eggs[randomegg], pos4[i].position, transform.rotation);


                }
            }
            else if (Marbles_MenuController.instance1.levelnum == 3)
            {
                for (i = 0; i < 3; i++)
                {
                    randomegg = Random.Range(0, eggs.Count);


                    Instantiate(eggs[randomegg], pos3[i].position, transform.rotation);


                }
            }
            else if (Marbles_MenuController.instance1.levelnum == 5)
            {
                for (i = 0; i < 5; i++)
                {
                    randomegg = Random.Range(0, eggs.Count);


                    Instantiate(eggs[randomegg], pos5[i].position, transform.rotation);


                }
            }
            else if (Marbles_MenuController.instance1.levelnum == 6)
            {
                for (i = 0; i < 6; i++)
                {
                    randomegg = Random.Range(0, eggs.Count);


                    Instantiate(eggs[randomegg], pos6[i].position, transform.rotation);


                }
            }
            else if (Marbles_MenuController.instance1.levelnum == 7)
            {
                for (i = 0; i < 7; i++)
                {
                    randomegg = Random.Range(0, eggs.Count);


                    Instantiate(eggs[randomegg], pos7[i].position, transform.rotation);


                }
            }
            yield return new WaitForSeconds(3f);
            GamePanel.SetActive(false);
            yesno.SetActive(true);
            isyesno = true;

        }
        else
        {
            yaww = true;
            if (Marbles_MenuController.instance1.levelnum == 4)
            {
                for (i = 0; i < 4; i++)
                {


                    Instantiate(eggs[pt[i]], pos4[i].position, transform.rotation);
                }
            }
            else if (Marbles_MenuController.instance1.levelnum == 3)
            {
                for (i = 0; i < 3; i++)
                {


                    Instantiate(eggs[pt[i]], pos3[i].position, transform.rotation);
                }
            }
            else if (Marbles_MenuController.instance1.levelnum == 5)
            {
                for (i = 0; i < 5; i++)
                {


                    Instantiate(eggs[pt[i]], pos5[i].position, transform.rotation);
                }
            }
            else if (Marbles_MenuController.instance1.levelnum == 6)
            {
                for (i = 0; i < 6; i++)
                {


                    Instantiate(eggs[pt[i]], pos6[i].position, transform.rotation);
                }
            }
            else if (Marbles_MenuController.instance1.levelnum == 7)
            {
                for (i = 0; i < 7; i++)
                {


                    Instantiate(eggs[pt[i]], pos7[i].position, transform.rotation);
                }
            }
            yield return new WaitForSeconds(3f);
            GamePanel.SetActive(false);
            yesno.SetActive(true);
            
            isyesno = true;
        }
    }
    public void Yes()
    {
        if (yaww == true)
        {
            yesno.SetActive(false);
            isyesno = false;
            timetextcorr.text = "Time Taken: " + timer;
            correctPanel.SetActive(true);
            GamePanel.SetActive(false);
            timer = 0;
        }
        else if (yaww == false)
        {
            if (Marbles_GameController.instance.pattern == pt)
            {
                yesno.SetActive(false);
                isyesno = false;
                timetextcorr.text = "Time Taken: " + timer;
                correctPanel.SetActive(true);
                GamePanel.SetActive(false);
                timer = 0;
            }
            else
            {
                yesno.SetActive(false);
                isyesno = false;
                timetextwrong.text = "Time Taken: " + timer;
                wrongPanel.SetActive(true);
                GamePanel.SetActive(false);
                timer = 0;
            }
        }
    }
    public void No()
    {
        if (yaww == true)
        {
            yesno.SetActive(false);
            isyesno = false;
            timetextwrong.text = "Time Taken: " + timer;
            wrongPanel.SetActive(true);
            GamePanel.SetActive(false);
            timer = 0;
        }
        else if (yaww == false)
        {
            if (Marbles_GameController.instance.pattern == pt)
            {
                yesno.SetActive(false);
                isyesno = false;
                timetextwrong.text = "Time Taken: " + timer;
                wrongPanel.SetActive(true);
                GamePanel.SetActive(false);
                timer = 0;
            }
            else
            {
                yesno.SetActive(false);
                isyesno = false;
                timetextcorr.text = "Time Taken: " + timer;
                correctPanel.SetActive(true);
                GamePanel.SetActive(false);
                timer = 0;
            }

        }
    }
    public void Back()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Goofy");
        foreach (GameObject go in gos)
            Destroy(go);

        GameObject[] gos2 = GameObject.FindGameObjectsWithTag("PoNeePo");
        foreach (GameObject go2 in gos2)
            Destroy(go2);

        SceneManager.LoadScene("Marbles_Menu");
    }
    public void Pause()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
        GamePanel.SetActive(false);
    }
    public void Pause2()
    {
        Time.timeScale = 0;
        PausePanel2.SetActive(true);
        GamePanel2.SetActive(false);
    }
    public void Resume()
    {
        PausePanel.SetActive(false);
        GamePanel.SetActive(true);
        Time.timeScale = 1;
    }
    public void Resume2()
    {
        PausePanel2.SetActive(false);
        GamePanel2.SetActive(true);
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
