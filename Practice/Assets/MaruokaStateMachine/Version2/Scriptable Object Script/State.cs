using System;
using UnityEngine;

/// <summary>
/// �X�e�[�g�̊��N���X
/// </summary>
public abstract class State : ScriptableObject
{
    [Tooltip("�����ƑJ�ڐ�̑g�ݍ��킹"), SerializeField]
    private Transition[] _transitions = default;

    /// <summary>
    /// ��ɂ��̒l�ɃA�N�Z�X���āA�Ǝ��̏�������������B
    /// </summary>
    protected SelfMadeStateMachine _owner = null;

    /// <summary>
    /// �I�[�i�[��ݒ肵�A
    /// �������ƃt�B�[���h�̏󋵂𓝈ꂷ��B
    /// </summary>
    /// <param name="owner"></param>
    /// <param name="sourceObj"></param>
    public void Setup(SelfMadeStateMachine owner, State sourceObj)
    {
        _owner = owner;
        _transitions = sourceObj._transitions;
        Enter();
    }
    /// <summary>
    /// �X�e�[�g�}�V�����疈�t���[���X�V����B
    /// </summary>
    public void Execute()
    {
        Update();
        OnTransition();
    }
    /// <summary>
    /// �������`�F�b�N���A�������������ꂽ��X�e�[�g��J�ڂ���B
    /// </summary>
    private void OnTransition()
    {
        // �S�Ă̑J�ڏ������`�F�b�N����
        for (int i = 0; i < _transitions.Length; i++)
        {
            // �X�e�[�g�}�V���̏�Ԃ��m�F���A�������������Ă�����J�ڂ���
            if (_owner.Conditions.HasFlag(_transitions[i].Conditions))
            {
                try
                {
                    // �V�����X�e�[�g�����蓖�Ă�i�X�N���v�^�u���I�u�W�F�N�g�̕����j
                    _owner.CurrentState = (State)ScriptableObject.CreateInstance(_transitions[i].NextState.GetType());
                }
                catch (InvalidCastException)
                {
                    Debug.LogWarning("�L���X�g�Ɏ��s���܂����B�J�ڂ��L�����Z�����܂��B");
                    return;
                }
                // ���X�e�[�g��Exit���������s
                this.Exit();
                // �������ꂽ�V�����X�e�[�g�ɑ΂��ăZ�b�g�A�b�v�������{���B
                _owner.CurrentState.Setup(_owner, _transitions[i].NextState);
                // �X�e�[�g�}�V���̏�Ԃ����Z�b�g
                _owner.Conditions = Conditions.None;
                return;
            }
        }
    }

    protected abstract void Enter();
    protected abstract void Update();
    protected abstract void Exit();

    /// <summary>
    /// �����ƑJ�ڐ�̑g�ݍ��킹
    /// </summary>
    [Serializable]
    private class Transition
    {
        [SerializeField]
        private Conditions _conditions = default;
        [SerializeField]
        private State _nextState = default;

        public Conditions Conditions => _conditions;
        public State NextState => _nextState;
    }
}
