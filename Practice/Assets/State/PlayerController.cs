using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    InputManager _input;
    [SerializeField] PlayerStateMachine _playerStateMachine;
    [SerializeField] Text _text;

    bool _canMove;
    public bool CanMove { get => _canMove; set => _canMove = value; }
    public InputManager Input => _input;
    public PlayerStateMachine PlayerStateMachine => _playerStateMachine;
    
    void Start()
    {
        _input = GetComponent<InputManager>();
        _playerStateMachine.Init(this);

        _text.text = _playerStateMachine.CurrentState.ToString();
    }

    void Update()
    {
        _playerStateMachine.Update();
        _text.text = _playerStateMachine.CurrentState.ToString();
    }
}
