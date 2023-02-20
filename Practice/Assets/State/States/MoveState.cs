using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MoveState : PlayerStateBase
{

    [SerializeField] Text text;
    public override void Enter()
    {
        Debug.Log("EnterMove");
        text.text = "EnterIdle";
    }
    public override void Update()
    {
        text.text = "Update Move";
        Debug.Log("Update Move");
        if (_playerStateMachine.Controller.Input.CanMove()) return;
        _playerStateMachine.TransitionTo(_playerStateMachine.Idle);
        //{
        //    _playerStateMachine.TransitionTo(_playerStateMachine.Idle);
        //    return;
        //}
    }
    public override void Exit()
    {
        Debug.Log("ExitMove");
        text.text = "ExitMove";
    }
}
