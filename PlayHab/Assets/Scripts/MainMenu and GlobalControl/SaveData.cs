using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class SaveData : MonoBehaviour
{
    public static SaveData instance;
    public string pName;
    public string game;
    public int diff;
    public string dT;
    public string tOs;
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

    public void OnAddDiff(int diffNo, string dt)
    {
        dT = dt;
        diff = diffNo;
    }

    public void OnAddTOS(string tos)
    {
        tOs = tos;
    }

    public void SaveToFile()
    {
        IndividualData iData = new IndividualData();
        iData.playerName = pName;
        iData.gameName = game;
        iData.difficulty = diff;
        iData.dateTime = dT;
        iData.timeOrScore = tOs;
        data.playerData.Add(iData);
        SaveToJson();
    }

    //private void Update()
    //{
    //    if(Input.GetKeyUp(KeyCode.S)) 
    //    {
    //        IndividualData iData = new IndividualData();
    //        iData.playerName = pName;
    //        iData.gameName = game;
    //        iData.difficulty = diff;
    //        iData.dateTime = dT;
    //        iData.timeOrScore = tOs;
    //        data.playerData.Add(iData);
    //        SaveToJson();
    //    }
    //}

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
        public string dateTime;
        public int difficulty;
        public string timeOrScore;
    }
}

