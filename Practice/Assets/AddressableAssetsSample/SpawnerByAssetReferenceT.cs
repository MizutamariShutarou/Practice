using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SpawnerByAssetReferenceT : MonoBehaviour
{
    [SerializeField] private AssetReferenceT<GameObject> prefabReference;

    private GameObject spawnedGameObject;

    private async void Start()
    {
        // InstantiateAsync�Ńv���n�u���C���X�^���X������
        AsyncOperationHandle<GameObject> handle = prefabReference.InstantiateAsync();

        // .Task�ŃC���X�^���X�������܂�await�ł���
        spawnedGameObject = await handle.Task;

        spawnedGameObject.name = "Spawned Game Object";
    }

    private void OnDestroy()
    {
        // �g���I�������C���X�^���X�������[�X����
        prefabReference.ReleaseInstance(spawnedGameObject);
    }
}