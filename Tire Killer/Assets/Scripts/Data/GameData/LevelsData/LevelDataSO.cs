using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewLevelData", menuName = "Data/Level Data")]
[Serializable]
public class LevelDataSO : ScriptableObject
{
    public string LevelID;
    public string LevelName;
    public bool isOpened;
    public bool Completed;
    public int Stars;
}
