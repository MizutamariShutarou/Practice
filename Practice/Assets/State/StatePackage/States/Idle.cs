using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Idle : IState
{
    PlayerController _playerController;
    public Idle(PlayerController playerController)
    {
        _playerController = playerController;
    }
    public void Enter()
    {
        Debug.Log("EnterIdle");
    }
    public void Update()
    {
        //if (_playerStateMachine.Controller.Input.CanMove() == false) return;
        //_playerStateMachine.TransitionTo(_playerStateMachine.Move);
        //{
        //    _playerStateMachine.TransitionTo(_playerStateMachine.Move);
        //}

        if (_playerController.Input.CanMove() == false) return;
        _playerController.StateMachine.TransitionTo(_playerController.Move);
    }
    public void Exit()
    {
        Debug.Log("ExitIdle");
    }
}
