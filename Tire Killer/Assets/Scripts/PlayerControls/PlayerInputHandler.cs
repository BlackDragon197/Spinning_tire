
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField]
    private PlayerData _playerData;
    public Vector2 MoveXInput { get; private set; }
    public Vector2 MoveYInput { get; private set; }

    public static Action OnDestroyObstacles;

    public bool SpeedBoostActivate { get; private set; }

    public void OnMoveXInput(InputAction.CallbackContext context)
    {
        MoveXInput = context.ReadValue<Vector2>();
    }


    public void OnMoveYInput(InputAction.CallbackContext context)
    {
        MoveYInput = context.ReadValue<Vector2>();
    }

    public void OnButton1Input(InputAction.CallbackContext context)
    {
        Debug.Log("Button 1");
        SpeedBoostActivate = context.ReadValueAsButton();

    }

    public void OnButton2Input(InputAction.CallbackContext context)
    {

        if (_playerData.CanDestroy)
        {
            Debug.Log("Button 2");
            OnDestroyObstacles(); 
            _playerData.CanDestroy = false;
        }
    }
}
