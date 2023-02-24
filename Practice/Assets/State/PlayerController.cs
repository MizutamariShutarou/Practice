using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] IdleState _idleState;

    [SerializeField] MoveState _moveState;

    InputManager _input;
    [SerializeField] PlayerStateMachine _playerStateMachine;
    //[SerializeField] Text _text;

    public InputManager Input => _input;
    public PlayerStateMachine PlayerStateMachine => _playerStateMachine;

    void Start()
    {
        _input = GetComponent<InputManager>();
        _playerStateMachine.Init(this);
        Init();
        //_text.text = _playerStateMachine.CurrentState.ToString();
    }

    void Update()
    {
        _playerStateMachine.Update();
        //_text.text = _playerStateMachine.CurrentState.ToString();
    }

    private void Init()
    {
        _idleState = new IdleState(this);
        _moveState = new MoveState(this);
    }
}
