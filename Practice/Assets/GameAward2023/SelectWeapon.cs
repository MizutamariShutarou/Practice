using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectWeapon : MonoBehaviour
{
    
    private MeshRenderer _myRenderer;
    private GameObject _go = default;

    [SerializeField] Material _material;

    SaveManager _saveManager;

    private void Start()
    {
        _saveManager = new SaveManager();
    }
    //public void Select(string weapon)
    //{
    //    if (weapon == "Taiken")
    //    {
    //        _saveManager.Load(SaveManager.Taiken);

    //        _myMesh.vertices = _saveManager.SaveData._myVertices;
    //        _myMesh.triangles = _saveManager.SaveData._myTriangles;

    //        CreateMesh(weapon);
    //    }
    //    else if (weapon == "Souken")
    //    {
    //        _saveManager.Load(SaveManager.Souken);

    //        _myMesh.vertices = _saveManager.SaveData._myVertices;
    //        _myMesh.triangles = _saveManager.SaveData._myTriangles;

    //        CreateMesh(weapon);
    //    }
    //    else if (weapon == "Hammer")
    //    {
    //        _saveManager.Load(SaveManager.Hammer);

    //        _myMesh.vertices = _saveManager.SaveData._myVertices;
    //        _myMesh.triangles = _saveManager.SaveData._myTriangles;

    //        CreateMesh(weapon);
    //    }
    //    else if (weapon == "Yari")
    //    {
    //        _saveManager.Load(SaveManager.Yari);

    //        _myMesh.vertices = _saveManager.SaveData._myVertices;
    //        _myMesh.triangles = _saveManager.SaveData._myTriangles;

    //        CreateMesh(weapon);
    //    }
        
    //}

    //private void CreateMesh(string weapon)
    //{
    //    _go = new GameObject(weapon + "MeshObj");
    //    _meshFilter = _go.AddComponent<MeshFilter>();
    //    _meshFilter.mesh = _myMesh;
    //    _myRenderer = _go.AddComponent<MeshRenderer>();
    //    _myRenderer.material = _material;
    //}

    public void CreateTaiken()
    {
        _saveManager.Load(SaveManager.Taiken);
        Mesh mesh = new Mesh();

        mesh.vertices = _saveManager.SaveData._myVertices;
        mesh.triangles = _saveManager.SaveData._myTriangles;

        _go = new GameObject("Taiken");

        MeshFilter meshFilter = _go.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        _myRenderer = _go.AddComponent<MeshRenderer>();
        _myRenderer.material = _material;
    }
    public void CreateSouken()
    {
        _saveManager.Load(SaveManager.Souken);
        Mesh mesh = new Mesh();

        mesh.vertices = _saveManager.SaveData._myVertices;
        mesh.triangles = _saveManager.SaveData._myTriangles;

        _go = new GameObject("Souken");

        MeshFilter meshFilter = _go.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        _myRenderer = _go.AddComponent<MeshRenderer>();
        _myRenderer.material = _material;
    }
    public void CreateHammer()
    {
        _saveManager.Load(SaveManager.Hammer);
        Mesh mesh = new Mesh();

        mesh.vertices = _saveManager.SaveData._myVertices;
        mesh.triangles = _saveManager.SaveData._myTriangles;

        _go = new GameObject("Hammer");

        MeshFilter meshFilter = _go.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        _myRenderer = _go.AddComponent<MeshRenderer>();
        _myRenderer.material = _material;
    }
    public void CreateYari()
    {
        _saveManager.Load(SaveManager.Yari);
        Mesh mesh = new Mesh();

        mesh.vertices = _saveManager.SaveData._myVertices;
        mesh.triangles = _saveManager.SaveData._myTriangles;

        _go = new GameObject("Yari");

        MeshFilter meshFilter = _go.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        _myRenderer = _go.AddComponent<MeshRenderer>();
        _myRenderer.material = _material;
    }
}
