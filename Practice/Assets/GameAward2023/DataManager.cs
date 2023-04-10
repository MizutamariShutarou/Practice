using System.IO;
using UnityEngine;

public class DataManager
{

    string filePath;
    SaveData save;

    public DataManager()
    {

        filePath = Application.dataPath + "/WeaponData.json";
        save = new SaveData();
    }

    // 省略。以下のSave関数やLoad関数を呼び出して使用すること

    public void Save()
    {
        string json = JsonUtility.ToJson(save);
        StreamWriter streamWriter = new StreamWriter(filePath);
        streamWriter.Write(json); streamWriter.Flush();
        streamWriter.Close();

    }

    public void Load()
    {
        if (File.Exists(filePath))
        {
            StreamReader streamReader;
            streamReader = new StreamReader(filePath);
            string data = streamReader.ReadToEnd();
            streamReader.Close();
            save = JsonUtility.FromJson<SaveData>(data);
        }
    }

}
