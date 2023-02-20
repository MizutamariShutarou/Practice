using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class MonsterScript : MonoBehaviour
{
    [SerializeField] float _speed;
    PlayerInput _input;
    Vector3 _velocity;
    Rigidbody _rb;
    void Start()
    {
        _input = GetComponent<PlayerInput>();
        _rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        if (_input == null)
            return;

        _input.onActionTriggered += OnMove;
    }

    private void OnDisable()
    {
        if (_input == null)
            return;

        _input.onActionTriggered -= OnMove;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        if (context.action.name != "Move")
            return;

        var axis = context.ReadValue<Vector2>();

        _velocity = new Vector3(axis.x, 0, axis.y);
    }

    void Update()
    {
        _rb.velocity = _velocity * _speed;
    }
}
