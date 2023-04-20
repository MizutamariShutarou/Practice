using Cysharp.Threading.Tasks;
using UnityEngine;

public class Sample : MonoBehaviour
{
    private async void Start()
    {
        Debug.Log("Start");

        // 非同期メソッドを呼び出す
        await DoAsync();

        Debug.Log("End");
    }

    private async UniTask DoAsync()
    {
        Debug.Log("DoAsync start");

        // 1秒待機する
        await UniTask.Delay(1000);

        Debug.Log("DoAsync end");
    }
}
