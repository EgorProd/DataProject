using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainGameManager : MonoBehaviour
{   
    public static MainGameManager Instance;
    public string playerName;
    public int bestScore;

    [System.Serializable]
    public class SaveData
    {
        public string playerName;
        public int bestScore;
    }

    public void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadNameAndScore();
    }

    public void SaveNameAndScore()
    {
        SaveData data = new SaveData();
        data.bestScore = bestScore;
        data.playerName = playerName;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadNameAndScore()
    {
        string path =  Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerName = data.playerName;
            bestScore = data.bestScore;
        }
        else
        {
            playerName = "Player";
            bestScore = 0;
        }
    }

    public void DeleteSavedData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            File.Delete(path);
            Debug.Log("Saved data deleted.");
        }
        else
        {
            Debug.Log("No saved data to delete");
        }
    }
    
    
}   

