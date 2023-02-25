using System;
using UnityEngine;

[System.Serializable]
public class StateMachineBase
{
    protected IState _currentState;
    public IState CurrentState => _currentState;

    public event Action<IState, IState> OnStateChanged = default;
    public void Initialize(IState startState)
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
}