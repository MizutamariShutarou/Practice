using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    PlayerInput _input;
    Vector3 _velocity;
    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
    }
    private void OnEnable()
    {
        if (_input == null)
            return;

        _input.onActionTriggered += OnMove;
        _input.onActionTriggered += OnJump;
    }

    private void OnDisable()
    {
        if (_input == null)
            return;

        _input.onActionTriggered -= OnMove;
        _input.onActionTriggered -= OnJump;
    }
    private void OnMove(InputAction.CallbackContext context)
    {
        if (context.action.name != "Move")
            return;

        var axis = context.ReadValue<Vector2>();

        _velocity = new Vector3(axis.x, 0, axis.y);
    }
    private void OnJump(InputAction.CallbackContext context)
    {
        if (context.action.name != "Jump")
        {
            return;
        }
    }

    public bool CanMove()
    {
        if (_velocity.magnitude >= 0.1f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
