using UnityEngine;

public class InputManager : MonoBehaviour
{
    private InputSystem _controls;

    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    private void Awake()
    {
        _controls = new InputSystem();
    }

    public float SideMoveValue()
    {
       return _controls.Player.Move.ReadValue<float>();
    }

    public bool JumpButtonWasClicked()
    {
        return _controls.Player.Jump.triggered;
    }

    public bool AtackButtonWasClicked()
    {
        return _controls.Player.Atack.triggered;
    }
}
