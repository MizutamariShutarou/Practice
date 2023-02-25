using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] IdleState _idleState;

    [SerializeField] MoveState _moveState;


    public IdleState IdleState => _idleState;
    public MoveState MoveState => _moveState;   

    InputManager _input;

    [SerializeField] Text _text;

    public InputManager Input => _input;


    private void Awake()
    {
        _input = GetComponent<InputManager>();

        InitState();
    }
    void Start()
    {
        Initialize(_idleState);
    }

    void Update()
    {
        if (_currentState != null)
        {
            _currentState.Update();
        }
        _text.text = _currentState.ToString();
        //_text.text = _playerStateMachine.CurrentState.ToString();
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

    private void InitState()
    {
        Debug.Log("各ステートをインスタンス化");
        _idleState = new IdleState(this);
       
        _moveState = new MoveState(this);
    }
}
