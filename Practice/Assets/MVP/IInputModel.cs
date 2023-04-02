using UniRx;

/// <summary>
/// Model��Presenter���q��Interface
/// </summary>
public interface IInputModelInterface
{
    /// <summary>
    /// �l�̊Ď��ɗ��p
    /// </summary>
    IReadOnlyReactiveProperty<string> InputTypeObservable { get; }

    /// <summary>
    /// �l�̔��s�ɗ��p
    /// </summary>
    void PublishValue();
}