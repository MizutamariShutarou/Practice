using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Move : IState
{
    PlayerController _playerController;
    public Move(PlayerController playerController)
    {
        _playerController = playerController;
    }
    public void Enter()
    {
        Debug.Log("EnterMove");
    }
    public void Update()
    {
        //if (_playerStateMachine.Controller.Input.CanMove()) return;
        //_playerStateMachine.TransitionTo(_playerStateMachine.Idle);
        //{
        //    _playerStateMachine.TransitionTo(_playerStateMachine.Idle);
        //    return;
        //}
        if (_playerController.Input.CanMove()) return;
        _playerController.StateMachine.TransitionTo(_playerController.Idle);
    }
    public void Exit()
    {
        Debug.Log("ExitMove");
    }
}
