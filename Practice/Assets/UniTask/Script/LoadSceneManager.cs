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
    public void ChangeScene(string name)
    {
        _cts = new CancellationTokenSource();
        LoadSceneExecute(name, _cts.Token).Forget();
    }
    private async UniTaskVoid LoadSceneExecute(string name, CancellationToken ct)
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
    }
}
