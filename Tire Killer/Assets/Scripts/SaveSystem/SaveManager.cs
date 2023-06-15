using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; private set; }

    [SerializeField]
    private GameDataSO _gameDataSO;

    [Serializable]
    public struct GameData
    {
        public string Name;
        public string Description;
        public LevelData LevelData;
    }
    [Serializable]
    public struct LevelData
    {
        public string Level;
        public string Info;
    }

    private GameData _gameData;
    private LevelData _levelData;

    public static string _dataPath = "";

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
 
        SetPath();
        CreateGameData();
        SaveGame();
    }

    private void SetPath()
    {
        _dataPath = Application.persistentDataPath + "/MySaveData.json";
    }

    private void CreateGameData()
    {
        _levelData = new LevelData
        {
            Level = "First Level",
            Info = "Hard"
        };
        _gameData = new GameData
        {
            Name = "Name1",
            Description = "GameDesk",
            LevelData = _levelData
        };
    }
    public void SaveGame()
    {
        string json = JsonUtility.ToJson(_gameData);
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

    public void LoadGame()
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

            GameData gameData = JsonUtility.FromJson<GameData>(json);
            Debug.Log(gameData.LevelData.Level);
            _gameDataSO.Name = gameData.LevelData.Level;
            _gameDataSO.Description = gameData.Description;

        }
        catch (Exception e)
        {
            Debug.LogError("Read Data Error: " + e);
        }



    }
    public void ResetData()
    {
        if (File.Exists(_dataPath))
        {
            Debug.LogError("There is no save data!");
            return;
        }
        Debug.LogError("No save data to delete.");
    }
}
