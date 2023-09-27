using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddName : MonoBehaviour
{
    Button button;
    SaveData saveData;
    public GameObject entry;

    private void Start()
    {
        button = GetComponent<Button>();
        saveData = FindObjectOfType<SaveData>().GetComponent<SaveData>();
        entry = GameObject.FindGameObjectWithTag("Text");
        button.onClick.AddListener(() => saveData.OnAddName(entry));
    }

    //public void Onclick()
    //{
    //    saveData.OnAddName(entry);
    //}
}
