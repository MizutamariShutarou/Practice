using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewNew : MonoBehaviour
{
    private MeshFilter _meshFilter;
    private Mesh _myMesh;
    void Start()
    {
        _meshFilter = GetComponent<MeshFilter>();
        _myMesh = new Mesh();

        var vertices = new[] { new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(0, 1, 0) };
        
        _myMesh.SetVertices(vertices);

        var indices = new [] { 0, 1, 1, 2, 2, 0 };

        _myMesh.SetIndices(indices, MeshTopology.Lines, 0);


        _meshFilter.mesh = _myMesh;
    }

    void Update()
    {
        
    }
}
