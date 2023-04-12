using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    /*public string _prefabName = default;
    public Vector3[] _myVertices = default;
    public int[] _myTriangles = default;*/

    [System.Serializable]
    public class WeaponData
    {
        public string _prefabName = default;
        public Vector3[] _myVertices = default;
        public int[] _myTriangles = default;
    }

    public List<WeaponData> WeaponList = new List<WeaponData>();
}
