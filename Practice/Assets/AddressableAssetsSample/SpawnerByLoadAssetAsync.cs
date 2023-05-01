using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SpawnerByLoadAssetAsync : MonoBehaviour
{
    private AsyncOperationHandle<GameObject> prefabHandle;
    private GameObject spawnedGameObject;

    private async void Start()
    {
        // Addressables.LoadAssetAsync�œǂݍ���
        prefabHandle = Addressables.LoadAssetAsync<GameObject>("Assets/AddressableAssetsSample/Sample.prefab");

        // .Task�œǂݍ��݊����܂�await�ł���
        GameObject prefab = await prefabHandle.Task;

        // �ǂݍ��񂾃v���n�u���C���X�^���X������
        spawnedGameObject = Instantiate(prefab);
        spawnedGameObject.name = "Spawned Game Object";
    }

    private void OnDestroy()
    {
        // �C���X�^���X������GameObject��j������
        Destroy(spawnedGameObject);

        // �g���I�������handle�������[�X����
        Addressables.Release(prefabHandle);
    }
}