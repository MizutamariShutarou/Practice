using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SpawnerByInstantiateAsync : MonoBehaviour
{
    private GameObject spawnedGameObject;

    private async void Start()
    {
        // Addressables.InstantiateAsync�Ńv���n�u���C���X�^���X������
        AsyncOperationHandle<GameObject> handle = Addressables.InstantiateAsync("Assets/AddressableAssetsSample/Sample.prefab");

        // .Task�ŃC���X�^���X�������܂�await�ł���
        spawnedGameObject = await handle.Task;

        spawnedGameObject.name = "Spawned Game Object";
    }

    private void OnDestroy()
    {
        // �g���I�������C���X�^���X�������[�X����
        Addressables.ReleaseInstance(spawnedGameObject);
    }
}