using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public string _prefabName;
    public Vector3[] _myVertices;
    public int[] _myTriangles;
    public List<Color> _colorList = new List<Color>();

    //[System.Serializable]
    //public class WeaponData
    //{
    //    public int _id = default;
    //    public Vector3[] _myVertices = default;
    //    public int[] _myTriangles = default;
    //}

    //public List<WeaponData> WeaponList = new List<WeaponData>();
}
