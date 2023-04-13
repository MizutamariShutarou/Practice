using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager
{
    private static string _taikenFilePath;

    public static string Taiken => _taikenFilePath;

    private static string _soukenFilePath;

    public static string Souken => _soukenFilePath;

    private static string _hammerFilePath;

    public static string Hammer => _hammerFilePath;

    private static string _yariFilePath;

    public static string Yari => _yariFilePath;

    public static List<string> _weaponFileList = new List<string>();

    private SaveData _saveData;

    public SaveData SaveData => _saveData;

    public void Initialize()
    {
        _taikenFilePath = Application.dataPath + "/TaikenData.json";
        _soukenFilePath = Application.dataPath + "/SoukenData.json";
        _hammerFilePath = Application.dataPath + "/HammerData.json";
        _yariFilePath = Application.dataPath + "/YariData.json";
        
        _weaponFileList = new List<string>() { _taikenFilePath, _soukenFilePath, _hammerFilePath, _yariFilePath};
    }

    public void Save(SaveData saveData, string filePath)
    {
        string json = JsonUtility.ToJson(saveData, true);
        StreamWriter streamWriter = new StreamWriter(filePath);
        streamWriter.Write(json);
        streamWriter.Flush();
        streamWriter.Close();
    }

    public void Load(string filePath)
    {
        if (File.Exists(filePath))
        {
            StreamReader streamReader;
            streamReader = new StreamReader(filePath);
            string data = streamReader.ReadToEnd();
            streamReader.Close();
            _saveData = JsonUtility.FromJson<SaveData>(data);
        }
    }

    public void ResetSaveData(string filePath)
    {
        _saveData = new SaveData();
        File.Delete(filePath);
    }
}
