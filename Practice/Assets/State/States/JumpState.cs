using UnityEngine;

[System.Serializable]
public class JumpState : IState
{
    PlayerController _playerController;
    public JumpState(PlayerController playerController)
    {
        _playerController = playerController;
    }

    public void Enter()
    {
        Debug.Log("EnterJump");
    }
    public void Update()
    {
        Debug.Log(_playerController.Input.CanMove());
    }
    public void Exit()
    {
        Debug.Log("ExitJump");
    }
}
