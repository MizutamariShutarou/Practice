using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    PlayerInput _input;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
    }
    private void OnEnable()
    {
        
    }
}
