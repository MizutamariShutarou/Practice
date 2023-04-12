using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;
using System.IO;

public class MeshActive : MonoBehaviour
{
    [SerializeField]
    private GameObject _panel;
    private MeshFilter _meshFilter;
    private Mesh _myMesh;
    private MeshRenderer _myRenderer;
    SaveManager _saveManager;


    private void Start()
    {
        _panel.SetActive(false);
        _saveManager = new SaveManager();

        _saveManager.Load();

        _myMesh = new Mesh();

        _myMesh.vertices = _saveManager.SaveData.WeaponList[0]._myVertices;
        _myMesh.triangles = _saveManager.SaveData.WeaponList[0]._myTriangles;

        /*_myMesh.vertices = _saveManager.WeaponData._myVertices;
        _myMesh.triangles = _saveManager.WeaponData._myTriangles;*/
        GameObject go = new GameObject("MeshObj");
        _meshFilter = go.AddComponent<MeshFilter>();
        _meshFilter.mesh = _myMesh;
        _myRenderer = go.AddComponent<MeshRenderer>();
        // _myRenderer.material = NewMeshManager._meshMaterial;

        // var ct = this.GetCancellationTokenOnDestroy();

        // AcyncStart(ct).Forget();
    }
    private async UniTask AcyncStart(CancellationToken ct)
    {
        try
        {
            // SaveManager.Load();
        }

        catch (NullReferenceException e)
        {
            Debug.LogError(e.Message);
            _panel.SetActive(true);
        }

        finally
        {
            await UniTask.CompletedTask;
        }
    }
}
/*[Serializable]
public class SaveMeshFilter
{
    private Mesh sharedMesh = null;
    private Mesh mesh = null;

    public static void Save(MeshFilter saveObj, string fileName)
    {
        var s = saveObj.sharedMesh;
        var m = saveObj.mesh;

        string jsonS = JsonUtility.ToJson(s);
        string jsonM = JsonUtility.ToJson(m);

        StreamWriter streamWriterS = new StreamWriter(fileName + "\\" + "s" + ".json");
        StreamWriter streamWriterM = new StreamWriter(fileName + "\\" + "m" + ".json");

        streamWriterS.Write(jsonS);
        streamWriterM.Write(jsonM);

        streamWriterS.Flush();
        streamWriterM.Flush();

        streamWriterS.Close();
        streamWriterM.Close();
    }
    public static MeshFilter Load(string fileName)
    {
        if (File.Exists(fileName))
        {
            var streamReaderS = new StreamReader(fileName + "\\" + "s" + ".json");
            var streamReaderM = new StreamReader(fileName + "\\" + "m" + ".json");

            string dataS = streamReaderS.ReadToEnd();
            string dataM = streamReaderM.ReadToEnd();

            streamReaderS.Close();
            streamReaderM.Close();

            var s = JsonUtility.FromJson<Mesh>(dataS);
            var m = JsonUtility.FromJson<Mesh>(dataM);

            var result = new MeshFilter();
            result.sharedMesh = s;
            result.mesh = m;

            return result;
        }
        return null;
    }
}*/
