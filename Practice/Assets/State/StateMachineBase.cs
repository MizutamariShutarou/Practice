using System;
using UnityEngine;

[System.Serializable]
public abstract class StateMachineBase
{
    public void Update()
    {
        if (_currentState != null)
        {
            _currentState.Update();
        }
    }
    protected IState _currentState;
    public IState CurrentState { get => _currentState; }

    public event Action<IState, IState> OnStateChanged = default;

    /// <summary>
    /// 最初のステートを設定する。
    /// </summary>
    /// <param name="startState"></param>
    protected void Initialize(IState startState)
    {
        StateInit();

        _currentState = startState;
        startState.Enter();

        // ステート変化時に実行するアクション。
        // 引数に最初のステートを渡す。
        OnStateChanged?.Invoke(null, startState);
    }

    /// <summary>
    /// ステートの遷移処理。引数に「次のステートの参照」を受け取る。
    /// </summary>
    /// <param name="nextState"></param>
    public void TransitionTo(IState nextState)
    {
        if (nextState == null)
        {
            Debug.LogError($"引数に渡された {nextState} はnullです。遷移をキャンセルします。");
            return;
        }
        var previousState = _currentState;
        _currentState.Exit();      // 現在ステートの終了処理。
        _currentState = nextState; // 現在のステートの変更処理。
        nextState.Enter();         // 変更された「新しい現在ステート」のEnter処理。

        // ステート変更時のアクションを実行する。
        // 引数に「新しい現在ステート」を渡す。
        OnStateChanged?.Invoke(previousState, nextState);
    }
    /// <summary>
    /// 各ステートにOwnerを渡す。
    /// </summary>
    protected abstract void StateInit();
}