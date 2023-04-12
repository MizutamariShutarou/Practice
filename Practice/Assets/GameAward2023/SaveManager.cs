using System.IO;
using UnityEngine;

public class SaveManager
{
    private string _filePath;

    private SaveData _saveData;
    public SaveData SaveData => _saveData;

    private SaveData.WeaponData _weaponData;

    public SaveData.WeaponData WeaponData => _weaponData;
    public SaveManager()
    {
        _filePath = Application.dataPath + "/WeaponData.json";
        _saveData = new SaveData();
        _weaponData = new SaveData.WeaponData();
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(_saveData, true);
        StreamWriter streamWriter = new StreamWriter(_filePath);
        streamWriter.Write(json); 
        streamWriter.Close();

    }

    public void Load()
    {
        if (File.Exists(_filePath))
        {
            StreamReader streamReader;
            streamReader = new StreamReader(_filePath);
            string data = streamReader.ReadToEnd();
            streamReader.Close();
            _saveData = JsonUtility.FromJson<SaveData>(data);
        }
    }

}
