using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveActions : MonoBehaviour
{
   public void SaveDataAction()
    {
        SaveManager.Instance.Save();
    }
}
