
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 MoveXInput { get; private set; }
    public Vector2 MoveYInput { get; private set; }

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
    }

    public void OnButton2Input(InputAction.CallbackContext context)
    {
        Debug.Log("Button 2");
    }


}
