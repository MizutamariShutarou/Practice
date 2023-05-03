using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class AsyncOperationHandleAwaitSample : MonoBehaviour
{
    /// <summary>
    /// “Ç‚İ‚Ş‘ÎÛ‚ÌAssetReference
    /// </summary>
    [SerializeField] AssetReference _target;

    [SerializeField] private RawImage _image;

    private void Start()
    {
        var token = this.GetCancellationTokenOnDestroy();
        InitializeAsync(_target, token).Forget();
    }

    private async UniTaskVoid InitializeAsync(
        AssetReference target,
        CancellationToken token)
    {
        // Addressables.LoadAssetAsync‚ğawait‚Å‘Ò‚¿ó‚¯‚é
        var texture = await Addressables.LoadAssetAsync<Texture>(target)
            .WithCancellation(token);

        _image.texture = texture;
    }
}