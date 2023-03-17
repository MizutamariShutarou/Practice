using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] EnemyIdle _idleState;

    [SerializeField] EnemyMove _moveState;

    public EnemyIdle IdleState => _idleState;
    public EnemyMove MoveState => _moveState;

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

    // �e�X�e�[�g�̏�����
    // �Ȃ�foreach�ł܂Ƃ߂ăC���X�^���X���Ƃ��ł�����
    // �X�e�[�g�������Ă��y����
    private void InitState()
    {
        StateMachine = new StateMachineBase();

        _idleState = new EnemyIdle(this);

        //_moveState = new MoveState(this);
    }
}
