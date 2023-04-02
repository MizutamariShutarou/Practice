using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class EditorInputModel : IInputModelInterface
{
    private StringReactiveProperty _inputType = new StringReactiveProperty();
    public IReadOnlyReactiveProperty<string> InputTypeObservable => _inputType;

    public void PublishValue()
    {
        _inputType.Value = Input.GetMouseButton(0) ? "Click" : "NoInput";
    }
}
