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

    // �e�X�e�[�g�̏�����
    // �Ȃ�foreach�ł܂Ƃ߂ăC���X�^���X���Ƃ��ł�����
    // �X�e�[�g�������Ă��y����
    private void InitState()
    {
        StateMachine = new StateMachineBase();

        _idle = new Idle(this);

        _move = new Move(this);

        _jump = new Jump(this);
    }


}
