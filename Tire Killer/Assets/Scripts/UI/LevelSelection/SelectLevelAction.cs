using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectLevelAction : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _levelName;

    private void Awake()
    {
        _levelName = GetComponentInChildren<TextMeshProUGUI>();
    }
    public void OpenLevel()
    {
        SceneLoader.Instance.LoadLevel("LevelScene");
        UIManager.Instance._uiState.InMenu = false;
        Debug.Log(_levelName.text);
    }
}
