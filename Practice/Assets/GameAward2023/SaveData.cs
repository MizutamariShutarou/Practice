using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    [System.Serializable]
    public class WeaponData
    {
        public string PrefabName;
        public Mesh _mesh;
        public MeshFilter _meshFilter;
    }

    public List<WeaponData> WeaponList = new List<WeaponData>();
}
