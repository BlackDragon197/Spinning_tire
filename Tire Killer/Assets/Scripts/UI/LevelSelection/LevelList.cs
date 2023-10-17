using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LevelList : MonoBehaviour
{

    [SerializeField]
    private GameObject _LevelElementUI;

    void Start()
    {
        var levelsData = SaveManager.Instance.GameDataSO.GetLevelsData();
        foreach (var level in levelsData)
        {
            var element = Instantiate(_LevelElementUI, transform);
            var text = element.GetComponentInChildren<TextMeshProUGUI>();
            text.text = level.LevelName;
        }
    }

}
