using UniRx;
using UniRx.Triggers;
using VContainer.Unity;

/// <summary>
/// VContainer�pPresenter�N���X
/// IPostInitializable���������邱�ƂŃ��C�t�T�C�N���C�x���g��^���邱�Ƃ��ł���
/// </summary>
public class VContainerTestPresenter : IPostInitializable
{
    private readonly IInputModelInterface _inputModelInterface;
    private readonly View _testView;

    //�R���X�g���N�^�C���W�F�N�V����
    public VContainerTestPresenter(IInputModelInterface inputModelInterface, View testView)
    {
        _inputModelInterface = inputModelInterface;
        _testView = testView;
    }

    /// <summary>
    /// ����������ɌĂ΂��
    /// </summary>
    public void PostInitialize()
    {
        //�l�̊Ď�
        _inputModelInterface.InputTypeObservable
            .Subscribe(inputType => { _testView.SetText(inputType); });

        //���͂����m������l�𔭍s
        _testView.UpdateAsObservable().Subscribe(_ => { _inputModelInterface.PublishValue(); });
    }
}