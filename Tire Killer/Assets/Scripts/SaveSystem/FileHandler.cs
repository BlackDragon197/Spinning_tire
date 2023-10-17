using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileHandler : MonoBehaviour
{


    [SerializeField]
    private LevelDataSO[] LevelSOs;

    private string _dataPath = "";
    private void Awake()
    {
        SetDataPath();
        if (!File.Exists(_dataPath))
        {
            SaveManager.Instance.GameDataSO.SaveLevelData(CreateLevelElements());
        }
    }

    private void SetDataPath()
    {
        _dataPath = Application.persistentDataPath + "/MySaveData.json";
    }

    private Level[] CreateLevelElements()
    {
        Level[] levels = new Level[LevelSOs.Length];
        for (var i = 0; i < levels.Length; i++)
        {
            levels[i] = new Level(LevelSOs[i].LevelID, LevelSOs[i].LevelName, LevelSOs[i].isOpened, LevelSOs[i].Completed, LevelSOs[i].Stars);
        }

        return levels;
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
