using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MoveState : PlayerStateBase
{
    public override void Enter()
    {
        //_playerStateMachine.Controller.CanMove = true;
        Debug.Log("EnterMove");
    }
    public override void Update()
    {
        if (!_playerStateMachine.Controller.Input.CanMove())
        {
            _playerStateMachine.TransitionTo(_playerStateMachine.Idle);
            return;
        }
    }
    public override void Exit()
    {
        //_playerStateMachine.Controller.CanMove = false;
        Debug.Log("ExitMove");
    }
}
