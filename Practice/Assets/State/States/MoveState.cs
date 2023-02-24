using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MoveState : IState
{
    [SerializeField] Text text;

    [System.NonSerialized]
    PlayerController _playerController;
    public MoveState(PlayerController playerController)
    {
        _playerController = playerController;
    }
    public void Enter()
    {
        Debug.Log("EnterMove");
        text.text = "EnterIdle";
    }
    public void Update()
    {
        text.text = "Update Move";
        Debug.Log("Update Move");
        //if (_playerStateMachine.Controller.Input.CanMove()) return;
        //_playerStateMachine.TransitionTo(_playerStateMachine.Idle);
        //{
        //    _playerStateMachine.TransitionTo(_playerStateMachine.Idle);
        //    return;
        //}
    }
    public void Exit()
    {
        Debug.Log("ExitMove");
        text.text = "ExitMove";
    }
}
