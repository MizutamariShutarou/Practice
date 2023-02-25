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
    /// �ŏ��̃X�e�[�g��ݒ肷��B
    /// </summary>
    /// <param name="startState"></param>
    protected void Initialize(IState startState)
    {
        _currentState = startState;
        startState.Enter();

        // �X�e�[�g�ω����Ɏ��s����A�N�V�����B
        // �����ɍŏ��̃X�e�[�g��n���B
        OnStateChanged?.Invoke(null, startState);
    }

    /// <summary>
    /// �X�e�[�g�̑J�ڏ����B�����Ɂu���̃X�e�[�g�̎Q�Ɓv���󂯎��B
    /// </summary>
    /// <param name="nextState"></param>
    public void TransitionTo(IState nextState)
    {
        if (nextState == null)
        {
            Debug.LogError($"�����ɓn���ꂽ {nextState} ��null�ł��B�J�ڂ��L�����Z�����܂��B");
            return;
        }
        var previousState = _currentState;
        _currentState.Exit();      // ���݃X�e�[�g�̏I�������B
        _currentState = nextState; // ���݂̃X�e�[�g�̕ύX�����B
        nextState.Enter();         // �ύX���ꂽ�u�V�������݃X�e�[�g�v��Enter�����B

        // �X�e�[�g�ύX���̃A�N�V���������s����B
        // �����Ɂu�V�������݃X�e�[�g�v��n���B
        OnStateChanged?.Invoke(previousState, nextState);
    }

    private void InitState()
    {
        Debug.Log("�e�X�e�[�g���C���X�^���X��");
        _idleState = new IdleState(this);
       
        _moveState = new MoveState(this);
    }
}
