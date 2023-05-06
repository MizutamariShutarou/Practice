using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject _weaponObj;
    [SerializeField]
    private GameObject _weaponHandle;
    private MeshRenderer _myRenderer;
    private GameObject _childObj = default;

    [SerializeField] Material _material;
    public void CreateTaiken()
    {
        SaveData data = SaveManager.Load(SaveManager.TAIKENFILEPATH);
        _weaponHandle.SetActive(true);

        Mesh mesh = new Mesh();
        mesh.vertices = data._myVertices;
        mesh.triangles = data._myTriangles;
        mesh.SetColors(data._colorList);

        _childObj = new GameObject(data._prefabName);
        _childObj.transform.parent = _weaponObj.transform;
        _weaponHandle.transform.position = MeshManager.HandlePos;

        MeshFilter meshFilter = _childObj.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        _myRenderer = _childObj.AddComponent<MeshRenderer>();
        _myRenderer.material = new Material(Shader.Find("Unlit/VertexColorShader"));
    }
    public void CreateSouken()
    {
        SaveData data = SaveManager.Load(SaveManager.SOUKENFILEPATH);
  
        Mesh mesh = new Mesh();
        mesh.vertices = data._myVertices;
        mesh.triangles = data._myTriangles;
        mesh.SetColors(data._colorList);

        //mesh.vertices = _saveManager.SaveData._myVertices;
        //mesh.triangles = _saveManager.SaveData._myTriangles;

        _childObj = new GameObject(data._prefabName);

        MeshFilter meshFilter = _childObj.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        _myRenderer = _childObj.AddComponent<MeshRenderer>();
        _myRenderer.material = _material;
        _myRenderer.material = new Material(Shader.Find("Unlit/VertexColorShader"));
    }
    public void CreateHammer()
    {
        SaveData data = SaveManager.Load(SaveManager.HAMMERFILEPATH);

        Mesh mesh = new Mesh();
        mesh.vertices = data._myVertices;
        mesh.triangles = data._myTriangles;
        mesh.SetColors(data._colorList);

        //mesh.vertices = _saveManager.SaveData._myVertices;
        //mesh.triangles = _saveManager.SaveData._myTriangles;

        _childObj = new GameObject(data._prefabName);

        MeshFilter meshFilter = _childObj.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        _myRenderer = _childObj.AddComponent<MeshRenderer>();
        _myRenderer.material = _material;
        _myRenderer.material = new Material(Shader.Find("Unlit/VertexColorShader"));
    }
    public void CreateYari()
    {
        SaveData data = SaveManager.Load(SaveManager.YARIFILEPATH);
        Debug.Log(data._prefabName);
        Debug.Log(data._myVertices);

        Mesh mesh = new Mesh();
        mesh.vertices = data._myVertices;
        mesh.triangles = data._myTriangles;
        mesh.SetColors(data._colorList);

        //mesh.vertices = _saveManager.SaveData._myVertices;
        //mesh.triangles = _saveManager.SaveData._myTriangles;

        _childObj = new GameObject(data._prefabName);

        MeshFilter meshFilter = _childObj.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        _myRenderer = _childObj.AddComponent<MeshRenderer>();
        _myRenderer.material = _material;
        _myRenderer.material = new Material(Shader.Find("Unlit/VertexColorShader"));
    }
}
