using System;
using UnityEngine;

public class SelfMadeStateMachine : MonoBehaviour
{
    [Tooltip("�ŏ��̃X�e�[�g"), SerializeField]
    private State _initState = default;
    /// <summary> ���݂̃X�e�[�g��\������l </summary>
    public State CurrentState { get; set; } = null;
    /// <summary> ���̒l��ύX���鎖�ŏ�Ԃ�J�ڂ���B </summary>
    public Conditions Conditions { get; set; } = Conditions.None;

    private void Start()
    {
        // �ŏ��̃X�e�[�g�����蓖�Ă�i�X�N���v�^�u���I�u�W�F�N�g�̕��������蓖�Ă�B�j
        CurrentState = (State)ScriptableObject.CreateInstance(_initState.GetType());
        // �V�����X�e�[�g�̃Z�b�g�A�b�v�������s��
        CurrentState.Setup(this, _initState);
    }
    private void Update()
    {
        CurrentState.Execute();
    }
}
/// <summary>
/// �J�ڂ̏�����\������񋓑�
/// </summary>
[Flags, Serializable]
public enum Conditions
{
    None = 0,
    Everything = -1,
    Idle = 1,
    Move = 2,
    Jump = 4,
}