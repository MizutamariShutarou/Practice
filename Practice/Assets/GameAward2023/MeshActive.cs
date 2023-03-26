using UnityEngine;

public class MeshActive : MonoBehaviour
{
    private MeshFilter _meshFilter;
    private Mesh _myMesh;
    private void Start()
    {
        _meshFilter = gameObject.GetComponent<MeshFilter>();
        _myMesh = new Mesh();

        _myMesh.SetVertices(NewMeshManager.MyVertices);
        _myMesh.SetTriangles(NewMeshManager.MyTriangles, 0);
        _meshFilter.mesh = _myMesh;

        for (int i = 0; i < NewMeshManager.MyVertices.Length; i++)
        {
            Debug.Log(NewMeshManager.MyVertices[i]);
        }
    }
}
