
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 XInput { get; private set; }
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        XInput = context.ReadValue<Vector2>();
    }


}
