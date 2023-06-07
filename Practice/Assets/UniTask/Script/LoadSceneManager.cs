using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    [SerializeField] Canvas _canvas = default;
    [SerializeField] Image _image = default;

    CancellationTokenSource _cts = default;
    public async UniTask ChangeScene(string name)
    {
        _cts = new CancellationTokenSource();
        await LoadSceneExecute(name, _cts.Token);
        Debug.Log("3");
    }

    // UniTask => 例外がcatchされないでGCの時に回収される
    // UniTaskVoid => UniTaskに比べて軽いし、例外がUniTaskSchedulerに格納される
    private async UniTask LoadSceneExecute(string name, CancellationToken ct) 
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(name);
        operation.allowSceneActivation = false;

        _image.fillAmount = 0f;
        _canvas.gameObject.SetActive(true);
        _image.fillAmount = operation.progress;

        await UniTask.WaitUntil(() => operation.progress >= 0.9f, cancellationToken : ct);
        _image.fillAmount = 1f;

        await UniTask.Delay(2000, cancellationToken : ct);
        _canvas.gameObject.SetActive(false);
        operation.allowSceneActivation = true;
        Debug.Log("2");
    }
}
