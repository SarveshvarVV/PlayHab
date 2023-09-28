using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallSaveToFile : MonoBehaviour
{
    SaveData saveData;
    Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        saveData = GameObject.FindObjectOfType<SaveData>().GetComponent<SaveData>();
        button.onClick.AddListener(() => saveData.SaveToFile());
    }
}
