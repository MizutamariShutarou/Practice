using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MoveState : IState
{
    [System.NonSerialized]
    PlayerController _playerController;
    public MoveState(PlayerController playerController)
    {
        _playerController = playerController;
    }
    public void Enter()
    {
        Debug.Log("EnterMove");
    }
    public void Update()
    {
        Debug.Log("Update Move");
        //if (_playerStateMachine.Controller.Input.CanMove()) return;
        //_playerStateMachine.TransitionTo(_playerStateMachine.Idle);
        //{
        //    _playerStateMachine.TransitionTo(_playerStateMachine.Idle);
        //    return;
        //}
        if (_playerController.Input.CanMove()) return;
        _playerController.TransitionTo(_playerController.IdleState);
        {
            _playerController.TransitionTo(_playerController.IdleState);
            return;
        }
    }
    public void Exit()
    {
        Debug.Log("ExitMove");
    }
}
