using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;

public class MeshActive : MonoBehaviour
{
    [SerializeField]
    private GameObject _panel;
    private MeshFilter _meshFilter;
    private Mesh _myMesh;

    private void Start()
    {
        _panel.SetActive(false);
        var ct = this.GetCancellationTokenOnDestroy();

        _meshFilter = gameObject.GetComponent<MeshFilter>();
        _myMesh = NewMeshManager._myMesh;
        AcyncStart(ct).Forget();
    }
    private async UniTask AcyncStart(CancellationToken ct)
    {
        try
        {
            var obj = (GameObject)Resources.Load(NewMeshManager.MeshName);
            Instantiate(obj, new Vector3(0, 0, 0), Quaternion.identity);
            _meshFilter.mesh = _myMesh;
        }

        catch(ArgumentException e)
        {
            Debug.LogError(e.Message);
            _panel.SetActive(true);
        }

        finally
        {
            Debug.Log($"{NewMeshManager.MeshName}çÏê¨");
            
            await UniTask.CompletedTask;
        }
    }
}
