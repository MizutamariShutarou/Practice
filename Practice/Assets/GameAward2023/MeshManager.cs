using UnityEngine;

public class MeshManager : MonoBehaviour
{
    private MeshFilter _meshFilter;
    private Mesh _myMesh;
    private Vector3[] _myVertices = new Vector3[4];
    private int[] _myTriangles = new int[6];
    private float _width = 2;
    private float _hight = 2;

    private float _dis = 1000f;

    Vector3 _closeMesh;


    void Start()
    {
        _meshFilter = gameObject.GetComponent<MeshFilter>();
        _myMesh = new Mesh();

        _myVertices[0] = new Vector3(-1, 0, 0); // ����
        _myVertices[1] = new Vector3(0, -1, 0); // �E��
        _myVertices[2] = new Vector3(0, 1, 0); // ����
        _myVertices[3] = new Vector3(1, 0, 0); // �E��

        _myMesh.SetVertices(_myVertices);

        Debug.Log(_myVertices[0]);
        Debug.Log(_myVertices[1]);
        Debug.Log(_myVertices[2]);
        Debug.Log(_myVertices[3]);

        _myTriangles[0] = 0;
        _myTriangles[1] = 2;
        _myTriangles[2] = 1;
        _myTriangles[3] = 2;
        _myTriangles[4] = 3;
        _myTriangles[5] = 1;

        _myMesh.SetTriangles(_myTriangles, 0);

        //MeshFilter�ւ̊��蓖��
        _meshFilter.mesh = _myMesh;
    }
    void Update()
    {
        //if (Input.GetKey(KeyCode.Space)) //�X�y�[�X�L�[�̓���
        //{
        //    for (int i = 0; i < _myVertices.Length; i++)
        //    {
        //        //���_�����炷
        //        _myVertices[i] += new Vector3(Random.Range(-0.05f, 0.05f), Random.Range(-0.05f, 0.05f));
        //    }
        //    _myMesh.SetVertices(_myVertices); //�V�������_�����蓖�Ă�

        //}

        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            var worldPos = Camera.main.ScreenToWorldPoint(mousePos);

            for(int i = 0; i < _myVertices.Length; i++)
            {
                float dis = Vector3.Distance(worldPos, _myVertices[i]);
                if(dis < _dis)
                {
                    _dis = dis;
                    _closeMesh = _myVertices[i];

                    float dis2 = worldPos.y - _closeMesh.y;

                    _myVertices[i] += new Vector3(0, dis2, 0);
                }
            }
            Debug.Log($"�����𑫂���{_closeMesh.y}");

            _myMesh.SetVertices(_myVertices);
            _dis = 1000f;
        }

    }
}
