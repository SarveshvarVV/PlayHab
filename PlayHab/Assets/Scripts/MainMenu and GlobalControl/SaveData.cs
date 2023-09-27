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
    public PlayerData data = new PlayerData();
    IndividualData iData = new IndividualData();


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != null)
        {
            Destroy(this);
        }
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
        iData.playerName = nameEntry.GetComponent<TextMeshProUGUI>().text.ToString();
        //data.playerData.Add(iData);
    }

    public void OnAddGame(GameObject gameEntry)
    {
        iData.gameName = gameEntry.name.ToString();
        //data.playerData.Add(iData);
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.S)) 
        {
            data.playerData.Append(iData);
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

