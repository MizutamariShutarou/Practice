using UniRx;
using UniRx.Triggers;
using VContainer.Unity;

/// <summary>
/// VContainer用Presenterクラス
/// IPostInitializableを実装することでライフサイクルイベントを与えることができる
/// </summary>
public class VContainerTestPresenter : IPostInitializable
{
    private readonly IInputModelInterface _inputModelInterface;
    private readonly View _testView;

    //コンストラクタインジェクション
    public VContainerTestPresenter(IInputModelInterface inputModelInterface, View testView)
    {
        _inputModelInterface = inputModelInterface;
        _testView = testView;
    }

    /// <summary>
    /// 初期化直後に呼ばれる
    /// </summary>
    public void PostInitialize()
    {
        //値の監視
        _inputModelInterface.InputTypeObservable
            .Subscribe(inputType => { _testView.SetText(inputType); });

        //入力を検知したら値を発行
        _testView.UpdateAsObservable().Subscribe(_ => { _inputModelInterface.PublishValue(); });
    }
}