using UniRx;

/// <summary>
/// ModelとPresenterを繋ぐInterface
/// </summary>
public interface IInputModelInterface
{
    /// <summary>
    /// 値の監視に利用
    /// </summary>
    IReadOnlyReactiveProperty<string> InputTypeObservable { get; }

    /// <summary>
    /// 値の発行に利用
    /// </summary>
    void PublishValue();
}