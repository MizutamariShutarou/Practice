using UnityEngine;
using Zenject;

/// <summary>
/// �ʂ�Input���@�ɕς������Ƃ���To�Œ�߂�������ύX���邾���ł悭�Ȃ�
/// </summary>
public class SampleInstaller : MonoInstaller
{
    /// <summary>
    /// IInputtable��K�v�Ƃ���N���X�̕ϐ�(_inputObject)��InputFromKeyboard�^�̃C���X�^���X�𒍓�
    /// </summary>
    public override void InstallBindings()
    {
        Container
            .Bind<IInputtable>()// �v������邩������Ȃ�interface
            .To<InputFromKeyboard>()// Bind�����N���X���̕ϐ��Ȃǂɒ�������C���X�^���X
            .AsSingle();// To�Œ�߂��C���X�^���X���ė��p(�V���O���g�����)
    }
}