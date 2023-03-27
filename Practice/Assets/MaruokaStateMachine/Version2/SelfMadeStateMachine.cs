using System;
using UnityEngine;

public class SelfMadeStateMachine : MonoBehaviour
{
    [Tooltip("最初のステート"), SerializeField]
    private State _initState = default;
    /// <summary> 現在のステートを表現する値 </summary>
    public State CurrentState { get; set; } = null;
    /// <summary> この値を変更する事で状態を遷移する。 </summary>
    public Conditions Conditions { get; set; } = Conditions.None;

    private void Start()
    {
        // 最初のステートを割り当てる（スクリプタブルオブジェクトの複製を割り当てる。）
        CurrentState = (State)ScriptableObject.CreateInstance(_initState.GetType());
        // 新しいステートのセットアップ処理を行う
        CurrentState.Setup(this, _initState);
    }
    private void Update()
    {
        CurrentState.Execute();
    }
}
/// <summary>
/// 遷移の条件を表現する列挙体
/// </summary>
[Flags, Serializable]
public enum Conditions
{
    None = 0,
    Everything = -1,
    Idle = 1,
    Move = 2,
    Jump = 4,
}