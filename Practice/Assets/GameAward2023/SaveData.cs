using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public string _prefabName = default;
    public Mesh _mesh = default;
    public MeshFilter _meshFilter = default;
    /*[System.Serializable]
    public class WeaponData
    {
        public string _prefabName = default;
        public Mesh _mesh = default;
        public MeshFilter _meshFilter = default;
    }

    public List<WeaponData> WeaponList = new List<WeaponData>();*/
}
