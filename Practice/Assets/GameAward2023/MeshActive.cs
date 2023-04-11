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
    DataManager _dataManager;


    private void Start()
    {
        _panel.SetActive(false);

        //_meshFilter = GetComponent<MeshFilter>();
        //_myMesh = new Mesh();
        //_meshFilter.sharedMesh = _myMesh;
        //_meshFilter.mesh = _myMesh;

        _myMesh = new Mesh();
        _myMesh.vertices = NewMeshManager.MyVertices;
        _myMesh.triangles = NewMeshManager.MyTriangles;
        // _myMesh = NewMeshManager.MyMesh;
        GameObject go = new GameObject("MeshObj");
        _meshFilter = go.AddComponent<MeshFilter>();
        _meshFilter.mesh = _myMesh;
        _myRenderer = go.AddComponent<MeshRenderer>();
        // _myRenderer.material = NewMeshManager._meshMaterial;

        // _myMesh.SetVertices(NewMeshManager.MyVertices);

        foreach(var v in NewMeshManager.MyVertices)
        {
            Debug.Log(v);
        }

        // var ct = this.GetCancellationTokenOnDestroy();

        // AcyncStart(ct).Forget();
    }
    private async UniTask AcyncStart(CancellationToken ct)
    {
        try
        {
            _dataManager.Load();
        }

        catch (NullReferenceException e)
        {
            Debug.LogError(e.Message);
            _panel.SetActive(true);
        }

        finally
        {
            Debug.Log(_dataManager);
            //_myMesh = _saveData._mesh;
            //_meshFilter = _saveData._meshFilter;
            //Debug.Log(_saveData._prefabName);
            //Debug.Log(_saveData._mesh);
            //Debug.Log(_saveData._meshFilter);

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
