using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddTOS : MonoBehaviour
{

    Text tos;
    SaveData saveData;
    void Start()
    {
        tos = GetComponent<Text>();
        saveData = FindObjectOfType<SaveData>().GetComponent<SaveData>();
        saveData.OnAddTOS(tos.text.ToString());
    }
}
