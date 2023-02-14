using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStateMachine : StateMachineBase
{
    [SerializeField] IdleState _idle;

    [SerializeField] MoveState _move;

    [SerializeField] JumpState _jump;

    public IdleState Idle => _idle;
    public MoveState Move => _move;
    public JumpState Jump => _jump;

    [SerializeField] PlayerController _controller;
    public void Init(PlayerController playerController)
    {
        _controller = playerController;
        Initialize(_idle);
    }
    protected override void StateInit()
    {
        _idle.Init(this);
        _move.Init(this);
        _jump.Init(this);
    }
}
