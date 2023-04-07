using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveMesh : MonoBehaviour
{
    [SerializeField] private string _path;

    private string _name = "TestMesh";

    private static int _num = 0;

    private static string _meshName;

    [SerializeField] GameObject _object;
    public static string MeshName => _meshName;

    [System.Obsolete]
    public void Change()
    {
        if(_num == 0)
        {
            _meshName = _name + $"{_num}";
            _path = "Assets/Resources/MeshFolder/" + _meshName + ".asset";
            AssetDatabase.CreateAsset(NewMeshManager.MeshFilter.mesh, _path);
            _num++;
        }
        else if(_num >= 1)
        {
            _meshName = _name + $"{_num}";
            _path = "Assets/Resources/MeshFolder/" + _meshName + ".asset";
            AssetDatabase.CreateAsset(NewMeshManager.MeshFilter.mesh, _path);
            _num++;
        }

        PrefabUtility.CreatePrefab("Assets/Resources/" + _meshName + ".prefab", _object);

        AssetDatabase.SaveAssets();

        SceneManager.LoadScene("BattleSample");
    }
}
