using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class IdleState : IState
{
    [SerializeField] Text text;

    [System.NonSerialized]
    PlayerController _playerController;
    public IdleState(PlayerController playerController)
    {
        _playerController = playerController;
    }
    public void Enter()
    {
        Debug.Log("EnterIdle");
        text.text = "EnterIdle";
    }
    public void Update()
    {
        text.text = "Update Idle";
        Debug.Log("Update Idle");
        //if (_playerStateMachine.Controller.Input.CanMove() == false) return;
        //_playerStateMachine.TransitionTo(_playerStateMachine.Move);
        //{
        //    _playerStateMachine.TransitionTo(_playerStateMachine.Move);
        //}
    }
    public void Exit()
    {
        Debug.Log("ExitIdle");
        text.text = "ExitIdle";
    }
}
