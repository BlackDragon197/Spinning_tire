using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; }

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

    public enum GameStates
    {
        START,
        INGAME,
        PAUSE,
        DEATH,
        END
    }

    public GameStates state;

    private void Start()
    {
        state = GameStates.START;
    }

    private void Update()
    {
        switch (state)
        {
            case GameStates.START:
                Time.timeScale = 0f;
                break;
            case GameStates.INGAME:
                LevelStart();
                break;
            case GameStates.PAUSE:
                LevelPaused();
                break;
            case GameStates.DEATH:
                LevelFailed();
                break;
            case GameStates.END:
                LevelEnded();
                break;

        }
    }

    public void ChangeState(GameStates State)
    {
        state = State;
    }

    public void LevelStart()
    {
        Time.timeScale = 1f;
        UIManager.Instance.CloseStartPanel();
        UIManager.Instance.ClosePausePanel();
    }

    public void LevelPaused()
    {
        Time.timeScale = 0f;
        UIManager.Instance.OpenPausePanel();
    }

    public void LevelFailed()
    {
        Time.timeScale = 0f;
        UIManager.Instance.OpenDeathPanel();

    }

    public void LevelEnded()
    {
        Time.timeScale = 0.1f;
        UIManager.Instance.OpenEndPanel();

    }

}
