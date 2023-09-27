using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;
using TMPro;
using System;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;
using System.Linq;

public class SaveData : MonoBehaviour
{
    public static SaveData instance;
    public string pName;
    public string game;
    public int diff;
    public float tOs;
    public PlayerData data = new PlayerData();


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != null)
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        LoadFromJson();
    }

    public void LoadFromJson()
    {
        string filepath = Application.persistentDataPath + "/SaveData.json";
        string savingData = File.ReadAllText(filepath);
        data = JsonUtility.FromJson<PlayerData>(savingData);
    }
    public void SaveToJson()
    {
        string savingData = JsonUtility.ToJson(data);
        string filepath = Application.persistentDataPath + "/SaveData.json";
        Debug.Log(filepath);
        File.WriteAllText(filepath, savingData);
        Debug.Log(savingData);
    }

    public void OnAddName(GameObject nameEntry)
    {
        pName = nameEntry.GetComponent<TextMeshProUGUI>().text.ToString();
        //data.playerData.Add(iData);
    }

    public void OnAddGame(GameObject gameEntry)
    {
        game = gameEntry.name.ToString();
        //data.playerData.Add(iData);
    }

    public void OnAddDiff(int diffNo)
    {
        diff = diffNo;
    }

    public void OnAddTOS(float tos)
    {
        tOs = tos;
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.S)) 
        {
            IndividualData iData = new IndividualData();
            iData.playerName = pName;
            iData.gameName = game;
            iData.difficulty = diff;
            iData.timeOrScore = tOs;
            data.playerData.Add(iData);
            SaveToJson();
        }
    }
    [System.Serializable]
    public class PlayerData
    {
        public List<IndividualData> playerData = new List<IndividualData>();
    }

    [System.Serializable]
    public class IndividualData
    {
        public string playerName;
        public string gameName;
        public int difficulty;
        public float timeOrScore;
    }
}

