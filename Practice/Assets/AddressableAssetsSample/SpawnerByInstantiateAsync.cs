using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SpawnerByInstantiateAsync : MonoBehaviour
{
    private GameObject spawnedGameObject;

    private async void Start()
    {
        // Addressables.InstantiateAsyncでプレハブをインスタンス化する
        AsyncOperationHandle<GameObject> handle = Addressables.InstantiateAsync("Assets/AddressableAssetsSample/Sample.prefab");

        // .Taskでインスタンス化完了までawaitできる
        spawnedGameObject = await handle.Task;

        spawnedGameObject.name = "Spawned Game Object";
    }

    private void OnDestroy()
    {
        // 使い終わったらインスタンスをリリースする
        Addressables.ReleaseInstance(spawnedGameObject);
    }
}