using System;
using UnityEngine;

[System.Serializable]
public class StateMachineBase
{
    protected IState _currentState;
    public IState CurrentState => _currentState;

    public event Action<IState, IState> OnStateChanged = default;
    //public void Initialize(IState startState)
    //{
    //    _currentState = startState;
    //    startState.Enter();

    //    // ステート変化時に実行するアクション。
    //    // 引数に最初のステートを渡す。
    //    OnStateChanged?.Invoke(null, startState);
    //}

    /// <summary>
    /// ステートの遷移処理。引数に「次のステートの参照」を受け取る。
    /// </summary>
    /// <param name="nextState"></param>
    public void TransitionTo(IState nextState)
    {
        var previousState = _currentState;
        // 初期化
        // _currentState(現在のステート)が何も設定されていなければ
        // 引数に最初のステートを渡す
        if (_currentState == null)
        {
            previousState = null;
            _currentState = nextState;
            nextState.Enter();

            OnStateChanged?.Invoke(previousState, nextState);
        }

        // 遷移処理
        // _currentState(現在のステート)になにか設定されていたら
        // 引数に遷移先のステートを渡す
        else if (_currentState != nextState)
        {
            previousState = _currentState;
            _currentState.Exit();      // 現在ステートの終了処理。
            _currentState = nextState; // 現在のステートの変更処理。
            nextState.Enter();         // 変更された「新しい現在ステート」のEnter処理。

            OnStateChanged?.Invoke(previousState, nextState);
        }
    }
}