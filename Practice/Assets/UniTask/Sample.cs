using Cysharp.Threading.Tasks;
using UnityEngine;

public class Sample : MonoBehaviour
{
    private async void Start()
    {
        Debug.Log("Start");

        // �񓯊����\�b�h���Ăяo��
        await DoAsync();

        Debug.Log("End");
    }

    private async UniTask DoAsync()
    {
        Debug.Log("DoAsync start");

        // 1�b�ҋ@����
        await UniTask.Delay(1000);

        Debug.Log("DoAsync end");
    }
}
