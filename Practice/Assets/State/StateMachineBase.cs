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

    //    // �X�e�[�g�ω����Ɏ��s����A�N�V�����B
    //    // �����ɍŏ��̃X�e�[�g��n���B
    //    OnStateChanged?.Invoke(null, startState);
    //}

    /// <summary>
    /// �X�e�[�g�̑J�ڏ����B�����Ɂu���̃X�e�[�g�̎Q�Ɓv���󂯎��B
    /// </summary>
    /// <param name="nextState"></param>
    public void TransitionTo(IState nextState)
    {
        var previousState = _currentState;
        // ������
        // _currentState(���݂̃X�e�[�g)�������ݒ肳��Ă��Ȃ����
        // �����ɍŏ��̃X�e�[�g��n��
        if (_currentState == null)
        {
            previousState = null;
            _currentState = nextState;
            nextState.Enter();

            OnStateChanged?.Invoke(previousState, nextState);
        }

        // �J�ڏ���
        // _currentState(���݂̃X�e�[�g)�ɂȂɂ��ݒ肳��Ă�����
        // �����ɑJ�ڐ�̃X�e�[�g��n��
        else if (_currentState != nextState)
        {
            previousState = _currentState;
            _currentState.Exit();      // ���݃X�e�[�g�̏I�������B
            _currentState = nextState; // ���݂̃X�e�[�g�̕ύX�����B
            nextState.Enter();         // �ύX���ꂽ�u�V�������݃X�e�[�g�v��Enter�����B

            OnStateChanged?.Invoke(previousState, nextState);
        }
    }
}