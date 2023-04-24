using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSample : MonoBehaviour
{
    [SerializeField] MeshManager _meshManager;

    [SerializeField, Tooltip("大剣のサンプル")]
    private List<Vector3> _taikenSample;

    [SerializeField, Tooltip("双剣のサンプル")]
    private List<Vector3> _soukenSample;

    [SerializeField, Tooltip("ハンマーのサンプル")]
    private List<Vector3> _hammerSample;

    [SerializeField, Tooltip("やりのサンプル")]
    private List<Vector3> _yariSample;

    public void SampleTaiken()
    {
        BaseSampleCreate(_taikenSample);
    }

    public void SampleSouken()
    {
        for (int i = 0; i < _soukenSample.Count; i++)
        {
            _meshManager.MyVertices[i] = _soukenSample[i];
            _meshManager.MyMesh.SetVertices(_soukenSample);
        }
    }

    public void SampleHammer()
    {
        BaseSampleCreate(_hammerSample);
    }

    private void BaseSampleCreate(List<Vector3> weaponList)
    {
        for(int i = 0; i < weaponList.Count; i++)
        {
            _meshManager.MyVertices[i] = weaponList[i];
            _meshManager.MyMesh.SetVertices(weaponList);
            if (_meshManager.SetColor.Count < weaponList.Count)
            {
                _meshManager.SetColor.Add(Color.black);
            }
        }
    }
}
