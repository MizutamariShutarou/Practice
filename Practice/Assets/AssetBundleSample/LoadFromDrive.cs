using System.Collections;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LoadFromDrive : MonoBehaviour
{
    [SerializeField]
    private string _assetName = default;

    [SerializeField]
    private Image _image = default;

    private CancellationTokenSource _cts = default;
    
    [System.Obsolete]
    private async void Start()
    {
        _cts = new CancellationTokenSource();
        await DownloadAsset(_cts.Token);
    }

    [System.Obsolete]
    private async UniTask DownloadAsset(CancellationToken token)
    {
        using (UnityWebRequest uwr = UnityWebRequestAssetBundle.GetAssetBundle
            ("https://drive.google.com/uc?export=download&id=12X3MlArdcZGZOOFWz6VWmCPEU1q2km0Z"))
        { 
        
        await uwr.SendWebRequest();

            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(uwr);
                var sprite = bundle.LoadAsset<Sprite>(_assetName);
                _image.sprite = sprite;
            }
        }
    }
}
