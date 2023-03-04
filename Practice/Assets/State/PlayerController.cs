using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] IdleState _idleState;

    [SerializeField] MoveState _moveState;

    [SerializeField] JumpState _jumpState;


    public IdleState IdleState => _idleState;
    public MoveState MoveState => _moveState;
    public JumpState JumpState => _jumpState;

    public StateMachineBase StateMachine { get; private set; }

    [SerializeField] Text _text;

    [SerializeField] InputManager _input;
    public InputManager Input => _input;


    private void Awake()
    {
        InitState();
    }
    void Start()
    {
        StateMachine.TransitionTo(_idleState);
    }

    void Update()
    {
        if (StateMachine.CurrentState != null)
        {
            StateMachine.CurrentState.Update();
        }
        _text.text = StateMachine.CurrentState.ToString();
        //_text.text = _playerStateMachine.CurrentState.ToString();
    }

    // 各ステートの初期化
    // なんかforeachでまとめてインスタンス化とかできたら
    // ステートが増えても楽かも
    private void InitState()
    {
        StateMachine = new StateMachineBase();

        _idleState = new IdleState(this);

        _moveState = new MoveState(this);

        _jumpState = new JumpState(this);
    }
}
