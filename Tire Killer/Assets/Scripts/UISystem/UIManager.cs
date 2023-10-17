using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject MainMenu;
    public GameObject CampaignMenu;
    public GameObject PauseMenu;
    public GameObject StartPanel;
    public GameObject DeathPanel;
    public GameObject EndPanel;
    public UIData _uiState;


    public static UIManager Instance { get; private set; }

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
        if (_uiState.firstStart)
        {
            _uiState.UiState.Add(MainMenu.name, true);
            _uiState.UiState.Add(CampaignMenu.name, false);
            _uiState.firstStart = false;
        }
        if (_uiState.UiState.ContainsKey(CampaignMenu.name) && _uiState.InMenu)
        {
            UpdateUI();
        }


    }
    public void SelectCampaign()
    {
        MainMenu.SetActive(false);
        CampaignMenu.SetActive(true);

        _uiState.UiState[MainMenu.name] = false;
        _uiState.UiState[CampaignMenu.name] = true;

        Debug.Log(_uiState.UiState[MainMenu.name]);
    }

    public void SelectMainMenu()
    {
        MainMenu.SetActive(true);
        CampaignMenu.SetActive(false);

        _uiState.UiState[MainMenu.name] = true;
        _uiState.UiState[CampaignMenu.name] = false;
    }

    public void UpdateUI()
    {
        Debug.Log("Entered");
        if (_uiState.UiState[CampaignMenu.name] == true)
        {
            Debug.Log("Incide");
            MainMenu.SetActive(false);
            CampaignMenu.SetActive(true);
        }
    }

    public void CloseStartPanel()
    {
        StartPanel.SetActive(false);
    }

    public void OpenPausePanel()
    {
        PauseMenu.SetActive(true);
    }

    public void ClosePausePanel()
    {
        PauseMenu.SetActive(false);
    }

    public void OpenDeathPanel()
    {
        DeathPanel.SetActive(true);
    }

    public void OpenEndPanel()
    {
        EndPanel.SetActive(true);
    }


}
