using UnityEngine;
using Zenject;

/// <summary>
/// 別のInput方法に変えたいときはToで定めた部分を変更するだけでよくなる
/// </summary>
public class SampleInstaller : MonoInstaller
{
    /// <summary>
    /// IInputtableを必要とするクラスの変数(_inputObject)にInputFromKeyboard型のインスタンスを注入
    /// </summary>
    public override void InstallBindings()
    {
        Container
            .Bind<IInputtable>()// 要求されるかもしれないinterface
            .To<InputFromKeyboard>()// Bindしたクラス内の変数などに注入するインスタンス
            .AsSingle();// Toで定めたインスタンスを再利用(シングルトン状態)
    }
}