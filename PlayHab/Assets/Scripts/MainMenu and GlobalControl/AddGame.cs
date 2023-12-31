using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class AddGame : MonoBehaviour
{
    GameObject gameobject;
    Button button;
    SaveData saveData;

    // Start is called before the first frame update
    void Start()
    {
        gameobject = this.gameObject;
        button = GetComponent<Button>();
        saveData = FindObjectOfType<SaveData>().GetComponent<SaveData>();
        button.onClick.AddListener(() => saveData.OnAddGame(gameobject));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
