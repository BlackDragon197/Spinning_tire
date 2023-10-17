using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStateActions : MonoBehaviour
{
    public void StartLevel()
    {
        GameStateManager.Instance.ChangeState(GameStateManager.GameStates.INGAME);
    }
}
