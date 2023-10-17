using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGameData", menuName = "Data/Game Data")]
[Serializable]
public class GameDataSO : ScriptableObject
{
    [SerializeField]
    private float Miles = 0;
    [SerializeField]
    private int DeathCount = 0;
    [SerializeField]
    private int Coins = 0;
    [SerializeField]
    private int Wheels = 0;
    [SerializeField]
    private int Wrenches = 0;
    [SerializeField]
    private Level[] LevelsData;


    public Level[] GetLevelsData()
    {
        return LevelsData;
    }

    public void SaveMiles(float miles)
    {
        Miles += miles;
    }
    public void SaveDeathCount()
    {
        DeathCount++;
    }

    public void SaveCoins(int coins)
    {
        Coins += coins;
    }

    public void SaveWheels(int wheels)
    {
        Wheels += wheels;
    }

    public void SaveWrenches(int wrenches)
    {
        Wrenches += wrenches;
    }

    public void SaveLevelData(Level[] levelsData)
    {
        LevelsData = levelsData;
    }
    public void SaveLevelData(string levelID, bool opened, bool completed, int stars)
    {
        var res = Array.Find(LevelsData, levelInfo => levelInfo.LevelID == levelID);

        res.isOpened = opened;
        res.Completed = completed;
        res.Stars = stars;
    }

    public void SaveLevelData(string levelID, bool opened)
    {
        var res = Array.Find(LevelsData, levelInfo => levelInfo.LevelID == levelID);

        res.isOpened = opened;
    }

    public void SpendCoins(int coins)
    {
        Coins -= coins;
    }

    public void SpendWheels(int wheels)
    {
        Wheels -= wheels;
    }

    public void SpendWrenches(int wrenches)
    {
        Wrenches -= wrenches;
    }
}
