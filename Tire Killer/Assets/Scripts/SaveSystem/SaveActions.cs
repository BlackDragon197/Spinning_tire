using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveActions : MonoBehaviour
{
    public void SaveInfo (){
    
    }
   public void LoadInfo()
    {
        SaveManager.Instance.LoadGame();
        Debug.Log("Info Loaded");
    }
}
