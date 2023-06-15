using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGameData", menuName = "Data/Game Data")]
public class GameDataSO : ScriptableObject
{
    public string Name;
    public string Description;
}
