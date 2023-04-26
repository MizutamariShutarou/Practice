#if UNITY_EDITOR
using System.IO;
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

/// <summary>
/// TODO : �o���̎��̃��b�V��2�쐬������ ?�@���
///      : ���b�V���������Ă��߂荞�ݔ��肪����ɓ����悤�ɂ���  ?�@����
///      : GameObject�𐶐�����悤�ɂ���@?�@�o���ȊO����
/// </summary>
public class MeshManager : MonoBehaviour
{
    /// <summary>
    /// �d�S�̈ʒu��\���I�u�W�F�N�g(��ŏ���)
    /// </summary>
    [SerializeField]
    private GameObject _go = default;

    [SerializeField, Tooltip("�o��ver")]
    private bool _isSouken = default;

    private MeshFilter _meshFilter = default;

    private Mesh _myMesh;
    public Mesh MyMesh => _myMesh;

    private MeshRenderer _meshRenderer;

    public Material _meshMaterial;

    private Vector3[] _myVertices = default;

    public Vector3[] MyVertices { get { return _myVertices; } }

    private int[] _myTriangles = default;

    private Vector3[] _myNormals = default;

    [SerializeField, Tooltip("�ő�͈�")]
    private float _maxDelta = default;

    [SerializeField, Tooltip("���_��")]
    private int _nVertices = 6;

    public int NVertices => _nVertices;

    private Vector2 _firstCenterPos = default;

    [SerializeField, Tooltip("���S�̍��W")]
    private Vector2 _centerPos = default;

    [SerializeField, Tooltip("�o���p�̒��S�̍��W")]
    private Vector3 _sCenterPos = default;

    [SerializeField, Tooltip("�傫��"), Range(0, 10)]
    private float _radius = 2f;

    [SerializeField, Tooltip("�@����͈�")]
    private float _minRange = 1.5f;

    private int _indexNum = default;

    private float _dis = 1000f;

    // public static bool _isFinished;

    private SaveData _saveData;

    public SaveData SaveData => _saveData;

    [SerializeField]
    private List<Color> _setColor = new List<Color>();

    public List<Color> SetColor { get { return _setColor; } }

    [ContextMenu("Make mesh from model")]

    private void Awake()
    {
        _myMesh = new Mesh();
        _saveData = new SaveData();
        SaveManager.Initialize();
    }

    void Start()
    {
        _firstCenterPos = _centerPos;
        foreach (var f in SaveManager._weaponFileList)
        {
            SaveManager.Load(f);
        }

        if (!_isSouken)
        {
            CreateMesh();
        }
        else
        {
            CreateSouken("Souken1", _sCenterPos.x, _sCenterPos.y);
            CreateSouken("Souken2", -_sCenterPos.x, _sCenterPos.y);
        }
    }
    void Update()
    {
        _myMesh.SetColors(_setColor);
        if (Input.GetMouseButtonDown(0))
        {
            Calculation();
            _centerPos = GetCentroid(_myVertices);
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
        worldPos.z = 0;

        for (int i = 0; i < _myVertices.Length; i++)
        {
            float dis = Vector3.Distance(worldPos, _myVertices[i]);
            if (dis < _dis)
            {
                _dis = dis;
                _indexNum = i;
            }
        }

        // �^�b�v�ʒu�Ƌ߂����_�Ƃ̋���(ti)
        float tiDis = Vector3.Distance(worldPos, _centerPos);

        // ���S�Ƌ߂����_�Ƃ̋���(io)
        float ioDis = Vector3.Distance(_myVertices[_indexNum], _centerPos);

        // ���S�ƃ^�b�v�ʒu�Ƃ̋���(to)
        float toDis = Vector3.Distance(worldPos, _centerPos);

        float disX = worldPos.x - _myVertices[_indexNum].x;
        float disY = worldPos.y - _myVertices[_indexNum].y;

        // �@�������_�����b�V���̓����ɓ��荞�ނ��Ƃ��������
        // ����X�^�[�g���̒��S���炸��Ȃ���Γ��荞�܂Ȃ�������Ƃ��
        // ���A�e���_������Ă����Ƃ��܂������Ȃ�(���S�_���A�����Ȃ�����)
        if (toDis < _minRange && toDis > ioDis)
        {
            Debug.Log("����ȏ㒆�ɑł����߂܂���");
            return;
        }

        if (Mathf.Abs(disX) < _radius / 3 && Mathf.Abs(disY) < _radius / 3)
        {
            _myVertices[_indexNum] -= new Vector3(disX, disY, 0);
        }
        else
        {
            Debug.Log($"�@�����ꏊ����ԋ߂����_{_indexNum}���痣�ꂷ���Ă܂�");
        }

        _myMesh.SetVertices(_myVertices);

        _dis = 1000f;
    }

    /// <summary>
    /// ����̃Z�[�u
    /// </summary>
    /// <param name="weapon"></param>
    public void OnSaveData(string weapon)
    {
        if (weapon == "Taiken")
        {
            _saveData._prefabName = weapon;
            _saveData._myVertices = _myVertices;
            _saveData._myTriangles = _myTriangles;
            _saveData._colorList = _setColor;
            SaveManager.Save(SaveManager.TAIKENFILEPATH, _saveData);
        }
        else if (weapon == "Souken")
        {
            _saveData._prefabName = weapon;
            _saveData._myVertices = _myVertices;
            _saveData._myTriangles = _myTriangles;
            _saveData._colorList = _setColor;
            SaveManager.Save(SaveManager.SOUKENFILEPATH, _saveData);
        }
        else if (weapon == "Hammer")
        {
            _saveData._prefabName = weapon;
            _saveData._myVertices = _myVertices;
            _saveData._myTriangles = _myTriangles;
            _saveData._colorList = _setColor;
            SaveManager.Save(SaveManager.HAMMERFILEPATH, _saveData);
        }
        else if (weapon == "Yari")
        {
            _saveData._prefabName = weapon;
            _saveData._myVertices = _myVertices;
            _saveData._myTriangles = _myTriangles;
            _saveData._colorList = _setColor;
            SaveManager.Save(SaveManager.YARIFILEPATH, _saveData);
        }
    }

    /// <summary>
    /// �S����̃Z�[�u�f�[�^�폜
    /// </summary>
    public void OnResetSaveData()
    {
        foreach (var f in SaveManager._weaponFileList)
        {
            SaveManager.ResetSaveData(f);
        }
    }

    public void ResetMeshShape()
    {
        if (_go == null)
            return;

        Destroy(_go);

        _centerPos = _firstCenterPos;
        CreateMesh();
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("BattleSample");
    }

    public void CreateMesh()
    {
        _go = new GameObject("WeaponBase");

        _meshFilter = _go.AddComponent<MeshFilter>();

        _meshRenderer = _go.AddComponent<MeshRenderer>();

        _myVertices = new Vector3[_nVertices];

        _myNormals = new Vector3[_nVertices];

        // ��ӓ�����̒��S�p�� 1 / 2
        float halfStep = Mathf.PI / _nVertices;

        for (int i = 0; i < _nVertices; i++)
        {
            // ���S���� i �Ԗڂ̒��_�Ɍ������p�x
            float angle = (i + 1) * halfStep;

            float x = _radius * Mathf.Cos(angle);

            float y = _radius * Mathf.Sin(angle);
            // �����̒��_�̈ʒu�Ɩ@��
            _myVertices[i].Set(_centerPos.x - x, _centerPos.y - y, 0);
            _myNormals[i] = Vector3.forward;
            i++;
            // �Ō�̒��_�𐶐�������I��
            if (i >= _nVertices) break;
            // �㑤�̒��_�̈ʒu�Ɩ@��
            _myVertices[i].Set(_centerPos.x - x, _centerPos.y + y, 0);
            _myNormals[i] = Vector3.forward;
        }

        _myMesh.SetVertices(_myVertices);

        _myMesh.SetNormals(_myNormals);

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
        _myMesh.SetColors(_setColor);
        _meshFilter.sharedMesh = _myMesh;
        _meshRenderer.material = new Material(Shader.Find("Unlit/VertexColorShader"));
        _meshFilter.mesh = _myMesh;
        _meshMaterial.SetInt("GameObject", (int)UnityEngine.Rendering.CullMode.Off);
    }

    private void CreateSouken(string name, float sX, float sY)
    {
        GameObject go = new GameObject(name);

        _meshFilter = go.AddComponent<MeshFilter>();

        _meshRenderer = go.AddComponent<MeshRenderer>();

        // _radiuses = new float[_nVertices];   

        _myVertices = new Vector3[_nVertices];

        _myNormals = new Vector3[_nVertices];

        // ��ӓ�����̒��S�p�� 1 / 2
        float halfStep = Mathf.PI / _nVertices;

        for (int i = 0; i < _nVertices; i++)
        {
            // ���S���� i �Ԗڂ̒��_�Ɍ������p�x
            float angle = (i + 1) * halfStep;

            float x = _radius * Mathf.Cos(angle);

            float y = _radius * Mathf.Sin(angle);
            // �����̒��_�̈ʒu�Ɩ@��
            _myVertices[i].Set(sX - x, sY - y, 0);
            _myNormals[i] = Vector3.forward;
            i++;
            // �Ō�̒��_�𐶐�������I��
            if (i >= _nVertices) break;
            // �㑤�̒��_�̈ʒu�Ɩ@��
            _myVertices[i].Set(sY - x, sY + y, 0);
            _myNormals[i] = Vector3.forward;
        }

        _myMesh.SetVertices(_myVertices);

        _myMesh.SetNormals(_myNormals);

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

        _myMesh.SetColors(_setColor);
        _meshFilter.sharedMesh = _myMesh;
        _meshRenderer.material = new Material(Shader.Find("Unlit/VertexColorShader"));
        _meshFilter.mesh = _myMesh;
        _meshMaterial.SetInt("GameObject", (int)UnityEngine.Rendering.CullMode.Off);
    }

    /// <summary>
    /// ���b�V���̏d�S���擾����֐�
    /// </summary>
    /// <param name="vertices"></param>
    /// <returns></returns>
    private Vector3 GetCentroid(Vector3[] vertices)
    {
        Vector3 centroid = Vector3.zero;
        float area = 0f;

        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 currentVertex = vertices[i];
            Vector3 nextVertex = vertices[(i + 1) % vertices.Length];

            float crossProduct = Vector3.Cross(currentVertex, nextVertex).magnitude;
            float triangleArea = 0.5f * crossProduct;

            area += triangleArea;
            centroid += triangleArea * (currentVertex + nextVertex) / 3f;
        }

        centroid /= area;

        return centroid;
    }
}




