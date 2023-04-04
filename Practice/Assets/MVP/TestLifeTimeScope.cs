using UnityEngine;
using VContainer;
using VContainer.Unity;

/// <summary>
/// VContainer用のContainerクラス
/// </summary>
public class TestLifeTimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        // DIなら
        // Container.Bind<IInputModel>.To<EditorInputModel>.AsSingle();
        builder.Register<IInputModelInterface, EditorInputModel>(Lifetime.Scoped);

        builder.RegisterComponentInHierarchy<View>();

        //VContainerTestPresenterはどこからもResolveされないので明示的にエントリーポイントとする
        builder.RegisterEntryPoint<VContainerTestPresenter>(Lifetime.Scoped);
    }
}