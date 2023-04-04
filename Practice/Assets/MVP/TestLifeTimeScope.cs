using UnityEngine;
using VContainer;
using VContainer.Unity;

/// <summary>
/// VContainer�p��Container�N���X
/// </summary>
public class TestLifeTimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        // DI�Ȃ�
        // Container.Bind<IInputModel>.To<EditorInputModel>.AsSingle();
        builder.Register<IInputModelInterface, EditorInputModel>(Lifetime.Scoped);

        builder.RegisterComponentInHierarchy<View>();

        //VContainerTestPresenter�͂ǂ������Resolve����Ȃ��̂Ŗ����I�ɃG���g���[�|�C���g�Ƃ���
        builder.RegisterEntryPoint<VContainerTestPresenter>(Lifetime.Scoped);
    }
}