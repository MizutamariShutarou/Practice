#if UNITY_EDITOR
using System.Collections.Generic;
using System.IO;
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeshManager : MonoBehaviour
{
    [SerializeField] GameObject _outlineObj;
    private MeshFilter _meshFilter = default;

    private Mesh _myMesh;

    private MeshRenderer _meshRenderer;

    public Material _meshMaterial;

    private Vector3[] _myVertices = default;

    private int[] _myTriangles = default;

    private int _uvVertices = default;

    private Vector3[] _myUvVertices = default;

    Vector2[] _myUVs = default;

    // private float[] _radiuses;

    [SerializeField, Tooltip("�ő�͈�")]
    private float _maxDelta = default;

    [SerializeField, Tooltip("���_��")]
    private int _nVertices = 6;

    [SerializeField, Tooltip("���S��x���W")]
    private float _x0 = 0f;

    [SerializeField, Tooltip("���S��y���W")]
    private float _y0 = 0f;

    [SerializeField, Tooltip("�傫��"), Range(0, 10)]
    private float _radius = 2f;

    [SerializeField, Tooltip("�A�E�g���C���p�̔��a"), Range(0, 10)]
    private float _outlineRadius = default;

    private int _indexNum = default;

    // private int _radiusIndexNum = default;

    private float _dis = 1000f;

    [SerializeField] private string _path;

    // public static bool _isFinished;

    private SaveData _saveData;

    public SaveData SaveData => _saveData;

    [SerializeField]
    private List<Color> _setColor = new List<Color>();

    [ContextMenu("Make mesh from model")]

    private void Awake()
    {
        _myMesh = new Mesh();
        _saveData = new SaveData();
        NewSaveManager.Initialize();
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshFilter = gameObject.GetComponent<MeshFilter>();
    }

    void Start()
    {
        CreateMesh();
    }
    void Update()
    {
        _myMesh.SetColors(_setColor);
       
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

        // �ȉ��ϐ������l������

        // �^�b�v�ʒu�Ƌ߂����_�Ƃ̋���(to)
        float toDis = Vector3.Distance(worldPos, new Vector3(_x0, _y0, 0));

        // ���S�Ƌ߂����_�Ƃ̋���(io)
        float ioDis = Vector3.Distance(_myVertices[_indexNum], new Vector3(_x0, _y0, 0));

        float disX = worldPos.x - _myVertices[_indexNum].x;
        float disY = worldPos.y - _myVertices[_indexNum].y;

        // float outlineDisX = worldPos.x - _outVertices[_indexNum].x;
        // float outlineDisY = worldPos.x - _outVertices[_indexNum].y;

        if (Mathf.Abs(disX) < _radius / 3 && Mathf.Abs(disY) < _radius / 3 /*disX < _radiuses[_radiusIndexNum] && disY < _radiuses[_radiusIndexNum]
                    dis2 < _radius*/)
        {
            _myVertices[_indexNum] -= new Vector3(disX, disY, 0);
            // _outVertices[_indexNum] -= new Vector3(outlineDisX, outlineDisY, 0);
            //_myVertices[_indexNum] = _closeMesh;
            // _radiuses[_radiusIndexNum] -= 0.1f;

            //if (_radiuses[_radiusIndexNum] <= 0)
            //{
            //    _radiuses[_radiusIndexNum] = 0.02f;
            //    Debug.Log($"��ԋ߂����_{_indexNum}���������鋗�����ŏ��l�ł�");

            //}

            // Debug.Log($"��ԋ߂����_{_indexNum}���������鋗����{_radiuses[_radiusIndexNum]}�ł�");

        }
        else
        {
            Debug.Log($"�@�����ꏊ����ԋ߂����_{_indexNum}���痣�ꂷ���Ă܂�");
        }

        _myMesh.SetVertices(_myVertices);
        _dis = 1000f;
    }
    public void OnSaveData(string weapon)
    {
        if (weapon == "Taiken")
        {
            _saveData._prefabName = weapon;
            _saveData._myVertices = _myVertices;
            _saveData._myTriangles = _myTriangles;
            _saveData._colorList = _setColor;
            NewSaveManager.Save(NewSaveManager.TAIKENFILEPATH, _saveData);
        }
        else if (weapon == "Souken")
        {
            _saveData._prefabName = weapon;
            _saveData._myVertices = _myVertices;
            _saveData._myTriangles = _myTriangles;
            _saveData._colorList = _setColor;
            NewSaveManager.Save(NewSaveManager.SOUKENFILEPATH, _saveData);
        }
        else if (weapon == "Hammer")
        {
            _saveData._prefabName = weapon;
            _saveData._myVertices = _myVertices;
            _saveData._myTriangles = _myTriangles;
            _saveData._colorList = _setColor;
            NewSaveManager.Save(NewSaveManager.HAMMERFILEPATH, _saveData);
        }
        else if (weapon == "Yari")
        {
            _saveData._prefabName = weapon;
            _saveData._myVertices = _myVertices;
            _saveData._myTriangles = _myTriangles;
            _saveData._colorList = _setColor;
            NewSaveManager.Save(NewSaveManager.YARIFILEPATH, _saveData);
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("BattleSample");
    }

    public void OnResetSaveData()
    {
        foreach (var f in NewSaveManager._weaponFileList)
        {
            NewSaveManager.ResetSaveData(f);
        }
    }

    public void CreateMesh()
    {
        foreach (var f in SaveManager._weaponFileList)
        {
            NewSaveManager.Load(f);
        }

        // _radiuses = new float[_nVertices];   
        _meshRenderer.material = _meshMaterial;

        _myVertices = new Vector3[_nVertices];

        _myUVs = new Vector2[_nVertices];

        Vector3[] myNormals = new Vector3[_nVertices];

        // ��ӓ�����̒��S�p�� 1 / 2
        float halfStep = Mathf.PI / _nVertices;

        //for(int i = 0; i < _nVertices; i++)
        //{
        //    _radiuses[i] = _radius;
        //    Debug.Log(_radiuses[i]);
        //}

        for (int i = 0; i < _nVertices; i++)
        {
            // ���S���� i �Ԗڂ̒��_�Ɍ������p�x
            float angle = (i + 1) * halfStep;

            float x = _radius * Mathf.Cos(angle);

            float y = _radius * Mathf.Sin(angle);
            // �����̒��_�̈ʒu�Ɩ@��
            _myVertices[i].Set(_x0 - x, _y0 - y, 0);
            myNormals[i] = Vector3.forward;
            i++;
            // �Ō�̒��_�𐶐�������I��
            if (i >= _nVertices) break;
            // �㑤�̒��_�̈ʒu�Ɩ@��
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
            // �P�ڂ̎O�p�`�̍ŏ��̒��_�̒��_�ԍ��̊i�[��
            int firstI = i * 3;
            // �P�ڂ̎O�p�`�̒��_�ԍ�
            _myTriangles[firstI + 0] = i;
            _myTriangles[firstI + 1] = i + 1;
            _myTriangles[firstI + 2] = i + 2;
            i++;
            // �Ō�̒��_�ԍ����i�[������I��
            if (i >= nPolygons) break;
            // �Q�ڂ̎O�p�`�̒��_�ԍ�
            _myTriangles[firstI + 3] = i + 2;
            _myTriangles[firstI + 4] = i + 1;
            _myTriangles[firstI + 5] = i;
        }

        _myMesh.SetTriangles(_myTriangles, 0);

        Vector2[] uvs = new Vector2[_nVertices];

        //for (int i = 0; i < _nVertices; i++)
        //{
        //    float angle = i * Mathf.PI * 2f / _nVertices;
        //    float x = (_myVertices[i].x - _x0) / (_radius * 2f) + 0.5f;
        //    float y = (_myVertices[i].y - _y0) / (_radius * 2f) + 0.5f;
        //    uvs[i] = new Vector2(x, y);
        //}

        // _myMesh.SetUVs(0, uvs);
        _myMesh.SetColors(_setColor);
        _meshFilter.sharedMesh = _myMesh;
        _meshRenderer.material = new Material(Shader.Find("Unlit/VertexColorShader"));
        _meshFilter.mesh = _myMesh;
    }
}




