using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class IdleState : PlayerStateBase
{
    [SerializeField] Text text;
    public override void Enter()
    {
        Debug.Log("EnterIdle");
        text.text = "EnterIdle";

    }
    public override void Update()
    {
        text.text = "Update Idle";
        Debug.Log("Update Idle");
        if (_playerStateMachine.Controller.Input.CanMove() == false) return;
        _playerStateMachine.TransitionTo(_playerStateMachine.Move);
        //{
        //    _playerStateMachine.TransitionTo(_playerStateMachine.Move);
        //}
    }
    public override void Exit()
    {
        Debug.Log("ExitIdle");
        text.text = "ExitIdle";
    }
}
