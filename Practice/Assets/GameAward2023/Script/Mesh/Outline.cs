using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline : MonoBehaviour
{
    private MeshFilter _meshFilter = default;

    private Mesh _myMesh;

    private MeshRenderer _meshRenderer;

    public Material _outlineMeshMaterial;

    private Vector3[] _myVertices = default;

    private int[] _myTriangles = default;

    private int _uvVertices = default;

    private Vector3[] _myUvVertices = default;

    Vector2[] _myUVs = default;

    // private float[] _radiuses;

    [SerializeField, Tooltip("最大範囲")]
    private float _maxDelta = default;

    [SerializeField, Tooltip("頂点数")]
    private int _nVertices = 6;

    [SerializeField, Tooltip("中心のx座標")]
    private float _x0 = 0f;

    [SerializeField, Tooltip("中心のy座標")]
    private float _y0 = 0f;

    [SerializeField, Tooltip("アウトライン用の半径"), Range(0, 10)]
    private float _outlineRadius = default;

    private int _indexNum = default;

    // private int _radiusIndexNum = default;

    private float _dis = 1000f;

    [SerializeField] private string _path;

    // public static bool _isFinished;

    private SaveData _saveData;

    public SaveData SaveData => _saveData;

    [SerializeField]
    private Color[] _setColor = new Color[6];

    [ContextMenu("Make mesh from model")]

    private void Awake()
    {
        _myMesh = new Mesh();
        _saveData = new SaveData();
        NewSaveManager.Initialize();
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshFilter = gameObject.GetComponent<MeshFilter>();
    }

    private void Start()
    {
        CreateOutline();
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
        //if (_isFinished)
        //{
        //    return;
        //}

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

        if (Mathf.Abs(disX) < _outlineRadius - 0.3f && Mathf.Abs(disY) < _outlineRadius - 0.3f /*disX < _radiuses[_radiusIndexNum] && disY < _radiuses[_radiusIndexNum]
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
        }
        else
        {
            Debug.Log($"叩いた場所が一番近い頂点{_indexNum}から離れすぎてます");
        }
        _dis = 1000f;
    }
    public void CreateOutline()
    {
        foreach (var f in SaveManager._weaponFileList)
        {
            NewSaveManager.Load(f);
        }

        // _radiuses = new float[_nVertices];   
        _meshRenderer.material = _outlineMeshMaterial;

        _myVertices = new Vector3[_nVertices];

        _myUVs = new Vector2[_nVertices];

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

            float x = _outlineRadius * Mathf.Cos(angle);

            float y = _outlineRadius * Mathf.Sin(angle);
            // 下側の頂点の位置と法線
            _myVertices[i].Set(_x0 - x, _y0 - y, 0);
            myNormals[i] = Vector3.forward;
            i++;
            // 最後の頂点を生成したら終了
            if (i >= _nVertices) break;
            // 上側の頂点の位置と法線
            _myVertices[i].Set(_x0 - x, _y0 + y, 0);
            myNormals[i] = Vector3.forward;
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

        //Vector2[] uvs = new Vector2[_nVertices];

        //for (int i = 0; i < _nVertices; i++)
        //{
        //    float angle = i * Mathf.PI * 2f / _nVertices;
        //    float x = (_myVertices[i].x - _x0) / (_outlineRadius * 2f) + 0.5f;
        //    float y = (_myVertices[i].y - _y0) / (_outlineRadius * 2f) + 0.5f;
        //    uvs[i] = new Vector2(x, y);
        //}

        //_myMesh.SetUVs(0, uvs);
        //_myMesh.SetColors(new Color[] { _setColor[0], _setColor[1], _setColor[2], _setColor[3], _setColor[4], _setColor[5] });
        _meshFilter.sharedMesh = _myMesh;
        //_meshRenderer.material = new Material(Shader.Find("Unlit/VertexColorShader"));
        _meshFilter.mesh = _myMesh;
    }
}
