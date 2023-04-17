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
        SaveData data = NewSaveManager.Load(NewSaveManager.TAIKENFILEPATH);
        Debug.Log(data._prefabName);

        Mesh mesh = new Mesh();
        mesh.vertices = data._myVertices;
        mesh.triangles = data._myTriangles;
        mesh.SetColors(data._colorList);
        //mesh.vertices = _saveManager.SaveData._myVertices;
        //mesh.triangles = _saveManager.SaveData._myTriangles;

        _go = new GameObject(data._prefabName);

        MeshFilter meshFilter = _go.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        _myRenderer = _go.AddComponent<MeshRenderer>();
        _myRenderer.material = new Material(Shader.Find("Unlit/VertexColorShader"));
    }
    public void CreateSouken()
    {
        SaveData data = NewSaveManager.Load(NewSaveManager.SOUKENFILEPATH);
  
        Mesh mesh = new Mesh();
        mesh.vertices = data._myVertices;
        mesh.triangles = data._myTriangles;
        mesh.SetColors(data._colorList);

        //mesh.vertices = _saveManager.SaveData._myVertices;
        //mesh.triangles = _saveManager.SaveData._myTriangles;

        _go = new GameObject(data._prefabName);

        MeshFilter meshFilter = _go.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        _myRenderer = _go.AddComponent<MeshRenderer>();
        _myRenderer.material = _material;
        _myRenderer.material = new Material(Shader.Find("Unlit/VertexColorShader"));
    }
    public void CreateHammer()
    {
        SaveData data = NewSaveManager.Load(NewSaveManager.HAMMERFILEPATH);

        Mesh mesh = new Mesh();
        mesh.vertices = data._myVertices;
        mesh.triangles = data._myTriangles;
        mesh.SetColors(data._colorList);

        //mesh.vertices = _saveManager.SaveData._myVertices;
        //mesh.triangles = _saveManager.SaveData._myTriangles;

        _go = new GameObject(data._prefabName);

        MeshFilter meshFilter = _go.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        _myRenderer = _go.AddComponent<MeshRenderer>();
        _myRenderer.material = _material;
        _myRenderer.material = new Material(Shader.Find("Unlit/VertexColorShader"));
    }
    public void CreateYari()
    {
        SaveData data = NewSaveManager.Load(NewSaveManager.YARIFILEPATH);
        Debug.Log(data._prefabName);
        Debug.Log(data._myVertices);

        Mesh mesh = new Mesh();
        mesh.vertices = data._myVertices;
        mesh.triangles = data._myTriangles;
        mesh.SetColors(data._colorList);

        //mesh.vertices = _saveManager.SaveData._myVertices;
        //mesh.triangles = _saveManager.SaveData._myTriangles;

        _go = new GameObject(data._prefabName);

        MeshFilter meshFilter = _go.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        _myRenderer = _go.AddComponent<MeshRenderer>();
        _myRenderer.material = _material;
        _myRenderer.material = new Material(Shader.Find("Unlit/VertexColorShader"));
    }
}
