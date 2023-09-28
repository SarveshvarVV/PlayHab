
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MC_AnswerAssign : MonoBehaviour
{
    public List<Button> options;
    public Text dummi;
    int rand;
    int rand2;
    int keepingCount;
    private List<int> randcheck = new List<int>();
    public bool yaww;

    public GameObject correctpanel;
    public GameObject incorrectpanel;

    public GameObject PauseMenu;
    public GameObject PauseButton;

    void Start()
    {
        dummi.text= "How many Black Cats were there in the picture?";
        rand = Random.Range(0, 4);
        
        options[rand].GetComponentInChildren<Text>().text = ("" + MC_GameController.instance.black);
        int choiceIndex = rand;
        options[rand].onClick.AddListener(() => CheckAnswer(choiceIndex));
        for (int i = 0; i < 4; i++)
        {
            if (i != rand)
            {
                RandButt(i);
            }

        }

    }
    
    public void RandButt(int i)
    {
        rand2 = Random.Range(1, 10);
        randcheck.Add(rand2);
        keepingCount++;
        if (rand2 != MC_GameController.instance.black && keepingCount > 1)
        {
            foreach (int val in randcheck)
            {
                if (rand2 != val)
                {
                    options[i].GetComponentInChildren<Text>().text = ("" + rand2);
                    int choicerat = i;
                    options[i].onClick.AddListener(() => CheckAnswer(choicerat));
                    //yaww = true;
                }
                

            }
            
        }
        else if(rand2 != MC_GameController.instance.black && keepingCount == 1)
        {
            options[i].GetComponentInChildren<Text>().text = ("" + rand2);
            int choicerat = i;
            options[i].onClick.AddListener(() => CheckAnswer(choicerat));
        }
        else
        {
            RandButt(i);
        }
        
    }
    private void CheckAnswer(int selectedChoiceIndex)
    {
        if (selectedChoiceIndex == rand)
        {
            Debug.Log("Correct!");
            MC_Timer.instance.Blackanswer();
            correctpanel.SetActive(true);

        }
        else
        {
            Debug.Log("Incorrect!");
            MC_Timer.instance.Blackanswer();
            incorrectpanel.SetActive(true);
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
        //PauseButton.SetActive(true);
        //PauseMenu.SetActive(false);
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

    //void choicemaker()
    //{
    //    int rand = Random.Range(0, 2);
    //    if (rand == 0)
    //    {
    //        BlackCount();
    //    }
    //    else
    //    {
    //        WhiteCount();
    //    }
    //}

    //void BlackCount()
    //{

    //    int bc = GameController.instance.black;
    //    text.text = "How many Black Cats were there in the picture?";
    //    AssignValueToButton(bc);
    //}

    //void WhiteCount()
    //{
    //    int wc = GameController.instance.white;
    //    text.text = "How many White Cats were there in the picture?";
    //    AssignValueToButton(wc);
    //}

    //void AssignValueToButton(int value)
    //{
    //    for (int i = 1; i < 5; i++)
    //    {


    //        int randomButton = i;

    //        switch (randomButton)
    //        {
    //            case 1:
    //                button1.GetComponentInChildren<Text>().text = "Count: " + value;
    //                button1.onClick.AddListener(() => ButtonClicked(value));
    //                break;
    //            case 2:
    //                button2.GetComponentInChildren<Text>().text = "Count: " + value;
    //                button2.onClick.AddListener(() => ButtonClicked(value));
    //                break;
    //            case 3:
    //                button3.GetComponentInChildren<Text>().text = "Count: " + value;
    //                button3.onClick.AddListener(() => ButtonClicked(value));
    //                break;
    //            case 4:
    //                button4.GetComponentInChildren<Text>().text = "Count: " + value;
    //                button4.onClick.AddListener(() => ButtonClicked(value));
    //                break;
    //        }
    //    }
    //}

    //void ButtonClicked(int value)
    //{
    //    Debug.Log("Button clicked. Value: " + value);
    //}
}   