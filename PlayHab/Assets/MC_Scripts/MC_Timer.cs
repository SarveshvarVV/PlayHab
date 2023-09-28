using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MC_Timer : MonoBehaviour
{
    public static MC_Timer instance;

    public float timer;

    public float blacktime;


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
    public void Blackanswer()
    {
        blacktime = timer;
        
    }
    
}
