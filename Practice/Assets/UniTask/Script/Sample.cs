using Cysharp.Threading.Tasks;
using UnityEngine;

public class Sample : MonoBehaviour
{
    private async void Start()
    {
        Debug.Log("Start");
        await DoAsync();
        var one = DoAsync1();
        var two = DoAsync2();
        var three = DoAsync3();

        // 非同期メソッドを呼び出す
        

        await UniTask.WhenAll(one, two, three);

        Debug.Log("End");
    }

    private async UniTask DoAsync()
    {
        Debug.Log("DoAsync start");

        // 1秒待機する
        await UniTask.DelayFrame(3000);

        Debug.Log("DoAsync end");
    }

    private async UniTask DoAsync1()
    {
        Debug.Log("1");
        await UniTask.CompletedTask;
    }
    private async UniTask DoAsync2()
    {
        Debug.Log("2");
        await UniTask.CompletedTask;
    }
    private async UniTask DoAsync3()
    {
        Debug.Log("3");
        await UniTask.CompletedTask;
    }
}
