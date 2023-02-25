using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class IdleState : IState
{
    [System.NonSerialized]
    PlayerController _playerController;
    public IdleState(PlayerController playerController)
    {
        _playerController = playerController;
    }
    public void Enter()
    {
        Debug.Log("EnterIdle");
    }
    public void Update()
    {
        Debug.Log("Update Idle");
        //if (_playerStateMachine.Controller.Input.CanMove() == false) return;
        //_playerStateMachine.TransitionTo(_playerStateMachine.Move);
        //{
        //    _playerStateMachine.TransitionTo(_playerStateMachine.Move);
        //}

        if (_playerController.Input.CanMove() == false) return;
        _playerController.TransitionTo(_playerController.MoveState);
    }
    public void Exit()
    {
        Debug.Log("ExitIdle");
    }
}
