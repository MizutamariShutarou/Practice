using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private string path;
    private static int num = 0;

    public void Change()
    {

#if UNITY_EDITOR
        if(num == 0)
        {
            AssetDatabase.CreateAsset(NewMeshManager.MeshFilter.mesh, "Assets/GameAward2023/MeshFolder/TestMesh" + $"{num}.asset");
            num++;
        }
        else if(num >= 1)
        { 
            AssetDatabase.CreateAsset(NewMeshManager.MeshFilter.mesh, "Assets/GameAward2023/MeshFolder/TestMesh" + $"{num}.asset");
            num++;
        }
        AssetDatabase.SaveAssets();
#endif

        SceneManager.LoadScene("BattleSample");
    }
}
