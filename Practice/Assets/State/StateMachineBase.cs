using System;
using UnityEngine;

[System.Serializable]
public abstract class StateMachineBase
{
    public void Update()
    {
        if (_currentState != null)
        {
            _currentState.Update();
        }
    }
    [NonSerialized]
    protected IState _currentState;
    public IState CurrentState { get => _currentState; }

    public event Action<IState, IState> OnStateChanged = default;

    // �ŏ��̃X�e�[�g��ݒ肷��B
    protected void Initialize(IState startState)
    {
        StateInit();

        _currentState = startState;
        startState.Enter();

        // �X�e�[�g�ω����Ɏ��s����A�N�V�����B
        // �����ɍŏ��̃X�e�[�g��n���B
        OnStateChanged?.Invoke(null, startState);

#if UNITY_EDITOR
        OnStateChanged +=
            (previousState, newState) =>
            {
                Debug.Log(
                    $"�v���C���[�̃X�e�[�g���ύX����܂����B\n" +
                    $"���݂̃X�e�[�g��\"{newState.GetType().Name}\"�ł��B");
            };
#endif
    }

    // �X�e�[�g�̑J�ڏ����B�����Ɂu���̃X�e�[�g�̎Q�Ɓv���󂯎��B
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
    protected abstract void StateInit();
}