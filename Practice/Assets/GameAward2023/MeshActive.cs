using UnityEngine;
using UnityEditor;
using Cysharp.Threading.Tasks;
using System.Threading;

public class MeshActive : MonoBehaviour
{
    private MeshFilter _meshFilter;
    private Mesh _myMesh;

    private void Start()
    {
        var ct = this.GetCancellationTokenOnDestroy();
        AcyncStart(ct).Forget();
    }
    private async UniTask AcyncStart(CancellationToken ct)
    {
        _meshFilter = gameObject.GetComponent<MeshFilter>();
        _myMesh = NewMeshManager._myMesh;

        //_myMesh.SetVertices(NewMeshManager.MyVertices);
        //_myMesh.SetTriangles(NewMeshManager.MyTriangles, 0);
        _meshFilter.mesh = _myMesh;

        await UniTask.NextFrame();

        var obj = (GameObject)Resources.Load(NewMeshManager.MeshName);
        Debug.Log(obj);
        Instantiate(obj, new Vector3(0, 0, 0), Quaternion.identity);

        //for (int i = 0; i < NewMeshManager.MyVertices.Length; i++)
        //{
        //    Debug.Log(NewMeshManager.MyVertices[i]);
        //}
    }
}
