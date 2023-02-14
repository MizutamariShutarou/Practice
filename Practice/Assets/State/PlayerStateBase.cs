using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateBase : IState
{
    [System.NonSerialized]
    protected PlayerStateMachine _playerStateMachine;

    public virtual void Init(PlayerStateMachine playerStateMachine)
    {
        _playerStateMachine = playerStateMachine;
    }
    public virtual void Enter()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Exit()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Update()
    {
        throw new System.NotImplementedException();
    }
}
