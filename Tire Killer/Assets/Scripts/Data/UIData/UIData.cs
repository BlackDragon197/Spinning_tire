using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UIData", menuName = "Data/UI Data")]
[Serializable]
public class UIData : ScriptableObject
{
    public bool InMenu = true;
    public bool firstStart = true;
  
    public Dictionary<string, bool> UiState = new Dictionary<string, bool>();



}
