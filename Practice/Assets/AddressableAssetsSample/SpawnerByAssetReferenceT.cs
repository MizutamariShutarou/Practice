using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SpawnerByAssetReferenceT : MonoBehaviour
{
    [SerializeField] private AssetReferenceT<GameObject> prefabReference;

    private GameObject spawnedGameObject;

    private async void Start()
    {
        // InstantiateAsyncでプレハブをインスタンス化する
        AsyncOperationHandle<GameObject> handle = prefabReference.InstantiateAsync();

        // .Taskでインスタンス化完了までawaitできる
        spawnedGameObject = await handle.Task;

        spawnedGameObject.name = "Spawned Game Object";
    }

    private void OnDestroy()
    {
        // 使い終わったらインスタンスをリリースする
        prefabReference.ReleaseInstance(spawnedGameObject);
    }
}