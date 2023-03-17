using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : IState
{
    EnemyController _enemyController;
    public EnemyIdle(EnemyController enemyController)
    {
        _enemyController = enemyController;
    }
    public void Enter()
    {
        Debug.Log("EnterEnemyIdle");
    }
    public void Update()
    {
        Debug.Log("UpdateEnemyIdle");
        //if (_playerStateMachine.Controller.Input.CanMove() == false) return;
        //_playerStateMachine.TransitionTo(_playerStateMachine.Move);
        //{
        //    _playerStateMachine.TransitionTo(_playerStateMachine.Move);
        //}
    }
    public void Exit()
    {
        Debug.Log("ExitIdle");
    }
}
