using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class IdleState : PlayerStateBase
{
    public override void Enter()
    {
        Debug.Log("EnterIdle");
    }
    public override void Update()
    {
        Debug.Log(_playerStateMachine.Controller.Input.CanMove());
        if(_playerStateMachine.Controller.Input.CanMove())
        {
            _playerStateMachine.TransitionTo(_playerStateMachine.Move);
            return;
        }
    }
    public override void Exit()
    {
        Debug.Log("ExitIdle");
    }
}
