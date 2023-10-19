using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MC_TimerW : MonoBehaviour
{
    public static MC_TimerW instance;
    public float timer;

    public float whitetime;

    public float avgtime;

    public Text correcttimetext;
    public Text wrongtimetext;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * 1f;
    }
    public void Whiteanswer()
    {
        whitetime = timer;
        avgtime = whitetime + MC_Timer.instance.blacktime;
        correcttimetext.text = "Time Taken:" + avgtime;
        wrongtimetext.text = "Task Failed Time Taken:" + avgtime;
        
    }
    
}
