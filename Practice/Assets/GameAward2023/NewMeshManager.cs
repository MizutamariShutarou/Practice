#if UNITY_EDITOR
using System.IO;
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMeshManager : MonoBehaviour
{
    private GameObject _go;
    private MeshFilter _meshFilter = default;
    public MeshFilter MeshFilter => _meshFilter;

    public Mesh _myMesh;

    private Mesh MyMesh => _myMesh;

    private MeshRenderer _meshRenderer;

    public MeshRenderer MeshRenderer;

    public Material _meshMaterial;

    private Vector3[] _myVertices = default;

    // public Vector3[] MyVertices => _myVertices;

    private int[] _myTriangles = default;

    // public static int[] MyTriangles => _myTriangles;

    // private float[] _radiuses;

    [SerializeField, Tooltip("最大範囲")]
    private float _maxDelta = default;

    [SerializeField, Tooltip("頂点数")]
    private int _nVertices = 6;

    [SerializeField, Tooltip("中心のx座標")]
    private float _x0 = 0f;

    [SerializeField, Tooltip("中心のy座標")]
    private float _y0 = 0f;

    [SerializeField, Tooltip("大きさ"), Range(0, 10)]
    private float _radius = 2f;

    private int _indexNum = default;

    // private int _radiusIndexNum = default;

    private float _dis = 1000f;

    [SerializeField] private string _path;

    // private int _num = 0;

    // private string _meshName;

    public static bool _isFinished;

    private SaveManager _saveManager;

    private SaveData _saveData;

    // private MitaraiSaveManager _saveManager;

    // public SaveData.WeaponData _data;

    /*private string _filePath;
    private SaveData _saveData;*/


    [ContextMenu("Make mesh from model")]

    private void Awake()
    {
        _saveData = new SaveData();
        _saveManager = new SaveManager();
        _saveManager.Initialize();
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshFilter = gameObject.GetComponent<MeshFilter>();
        _myMesh = new Mesh();

        // _data = new SaveData.WeaponData();
    }

    void Start()
    {
        foreach (var f in SaveManager._weaponFileList)
        {
            _saveManager.Load(f);
        }

        // _radiuses = new float[_nVertices];   
        _meshMaterial = _meshRenderer.material;

        _myVertices = new Vector3[_nVertices];

        Vector3[] myNormals = new Vector3[_nVertices];

        // 一辺当たりの中心角の 1 / 2
        float halfStep = Mathf.PI / _nVertices;

        //for(int i = 0; i < _nVertices; i++)
        //{
        //    _radiuses[i] = _radius;
        //    Debug.Log(_radiuses[i]);
        //}

        for (int i = 0; i < _nVertices; i++)
        {
            // 中心から i 番目の頂点に向かう角度
            float angle = (i + 1) * halfStep;

            float x = _radius * Mathf.Cos(angle);

            float y = _radius * Mathf.Sin(angle);
            // 下側の頂点の位置と法線
            _myVertices[i].Set(_x0 - x, _y0 - y, 0);
            myNormals[i] = Vector3.back;
            i++;
            // 最後の頂点を生成したら終了
            if (i >= _nVertices) break;
            // 上側の頂点の位置と法線
            _myVertices[i].Set(_x0 - x, _y0 + y, 0);
            myNormals[i] = Vector3.back;
        }
        _myMesh.SetVertices(_myVertices);

        _myMesh.SetNormals(myNormals);

        int nPolygons = _nVertices - 2;
        int nTriangles = nPolygons * 3;

        _myTriangles = new int[nTriangles];

        for (int i = 0; i < nPolygons; i++)
        {
            // １つ目の三角形の最初の頂点の頂点番号の格納先
            int firstI = i * 3;
            // １つ目の三角形の頂点番号
            _myTriangles[firstI + 0] = i;
            _myTriangles[firstI + 1] = i + 1;
            _myTriangles[firstI + 2] = i + 2;
            i++;
            // 最後の頂点番号を格納したら終了
            if (i >= nPolygons) break;
            // ２つ目の三角形の頂点番号
            _myTriangles[firstI + 3] = i + 2;
            _myTriangles[firstI + 4] = i + 1;
            _myTriangles[firstI + 5] = i;
        }

        _myMesh.SetTriangles(_myTriangles, 0);

        _meshFilter.mesh = _myMesh;

        Debug.Log(_myVertices);
        Debug.Log(_myTriangles);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Calculation();
        }
    }

    void Calculation()
    {
        if (_isFinished)
        {
            return;
        }

        Vector3 mousePos = Input.mousePosition;
        var worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        for (int i = 0; i < _myVertices.Length; i++)
        {
            float dis = Vector3.Distance(worldPos, _myVertices[i]);
            if (dis < _dis)
            {
                _dis = dis;
                _indexNum = i;
                //_radiusIndexNum = i;
            }
        }

        // 以下変数名を考えたい

        // タップ位置と近い頂点との距離(to)
        float toDis = Vector3.Distance(worldPos, new Vector3(_x0, _y0, 0));

        // 中心と近い頂点との距離(io)
        float ioDis = Vector3.Distance(_myVertices[_indexNum], new Vector3(_x0, _y0, 0));

        float disX = worldPos.x - _myVertices[_indexNum].x;
        float disY = worldPos.y - _myVertices[_indexNum].y;

        if (Mathf.Abs(disX) < _radius && Mathf.Abs(disY) < _radius /*disX < _radiuses[_radiusIndexNum] && disY < _radiuses[_radiusIndexNum]
                    dis2 < _radius*/)
        {
            _myVertices[_indexNum] -= new Vector3(disX, disY, 0);
            //_myVertices[_indexNum] = _closeMesh;
            // _radiuses[_radiusIndexNum] -= 0.1f;

            //if (_radiuses[_radiusIndexNum] <= 0)
            //{
            //    _radiuses[_radiusIndexNum] = 0.02f;
            //    Debug.Log($"一番近い頂点{_indexNum}が反応する距離が最小値です");

            //}

            // Debug.Log($"一番近い頂点{_indexNum}が反応する距離は{_radiuses[_radiusIndexNum]}です");

            _myMesh.SetVertices(_myVertices);

            //MakeMesh();
        }
        else
        {
            Debug.Log($"叩いた場所が一番近い頂点{_indexNum}から離れすぎてます");
        }
        _dis = 1000f;
    }
    public void OnSaveData(string weapon)
    {
        if (weapon == "Taiken")
        {
            _saveManager.SaveData._prefabName = weapon;
            _saveManager.SaveData._myVertices = _myVertices;
            _saveManager.SaveData._myTriangles = _myTriangles;
            _saveManager.Save(_saveManager.SaveData, SaveManager.Taiken);
        }
        else if (weapon == "Souken")
        {
            _saveManager.SaveData._prefabName = weapon;
            _saveManager.SaveData._myVertices = _myVertices;
            _saveManager.SaveData._myTriangles = _myTriangles;
            _saveManager.Save(_saveManager.SaveData, SaveManager.Souken);
        }
        else if (weapon == "Hammer")
        {
            _saveManager.SaveData._prefabName = weapon;
            _saveManager.SaveData._myVertices = _myVertices;
            _saveManager.SaveData._myTriangles = _myTriangles;
            _saveManager.Save(_saveManager.SaveData, SaveManager.Hammer);
        }
        else if (weapon == "Yari")
        {
            _saveManager.SaveData._prefabName = weapon;
            _saveManager.SaveData._myVertices = _myVertices;
            _saveManager.SaveData._myTriangles = _myTriangles;
            _saveManager.Save(_saveManager.SaveData, SaveManager.Yari);
        }

        // _saveManager.SaveData.WeaponList.Add(_saveManager.WeaponData);

        // Debug.Log(_saveManager.SaveData.WeaponList[_meshId]);

        //_saveManager.SaveData.WeaponList[_meshId]._id = _meshId;

        //_saveManager.SaveData.WeaponList[_meshId]._myVertices = _myVertices;

        //_saveManager.SaveData.WeaponList[_meshId]._myTriangles = _myTriangles;

        //_saveManager.Save();
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("BattleSample");
    }

    public void OnResetSaveData()
    {
        foreach (var f in SaveManager._weaponFileList)
        {
            _saveManager.ResetSaveData(f);
        }
    }

    public void OnAddSaveData()
    {
        
    }
}
