using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerController : MonoBehaviour
{
    [SerializeField] Idle _idle;

    [SerializeField] Move _move;

    [SerializeField] Jump _jump;

    public Idle Idle => _idle;
    public Move Move => _move;
    public Jump Jump => _jump;

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
        StateMachine.TransitionTo(_idle);
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

        _idle = new Idle(this);

        _move = new Move(this);

        _jump = new Jump(this);
    }


}
