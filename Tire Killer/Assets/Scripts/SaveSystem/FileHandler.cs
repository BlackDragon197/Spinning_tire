using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileHandler : MonoBehaviour
{
    private string _dataPath = "";
    private void Awake()
    {
        SetDataPath();
    }
    private void SetDataPath()
    {
        _dataPath = Application.persistentDataPath + "/MySaveData.json";
    }
    public void SaveToFile(GameDataSO gameDataObject)
    {
        string json = JsonUtility.ToJson(gameDataObject);
        using StreamWriter writer = new StreamWriter(_dataPath);

        try
        {
            writer.Write(json);
            Debug.Log("Game data saved!");
        }
        catch (Exception e)
        {
            Debug.Log("Save Error: " + e);
        }
    }

    public void LoadFromFile()
    {
        if (!File.Exists(_dataPath))
        {
            Debug.LogError("There is no save data!");
            return;
        }
        try
        {
            using StreamReader reader = new StreamReader(_dataPath);
            string json = reader.ReadToEnd();
            JsonUtility.FromJsonOverwrite(json, SaveManager.Instance.GameDataSO);

        }
        catch (Exception e)
        {
            Debug.LogError("Read Data Error: " + e);
        }
    }
}
