using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class MitaraiSaveManager
{
    static MitaraiSaveManager Instance = new MitaraiSaveManager();

#if RELEASE
    const string FILEPATH = "save.dat";
#else
    const string FILEPATH = "save.txt";
#endif
    SaveData Data = null;

    static public void Load()
    {
        Instance.Data = LocalData.Load<SaveData>(FILEPATH);
        if (Instance.Data == null)
        {
            Instance.Data = new SaveData();
        }
    }

    static public SaveData GetData()
    {
        if (Instance.Data == null)
        {
            Load();
        }
        return Instance.Data;
    }

    static public void Save()
    {
        LocalData.Save<SaveData>(FILEPATH, Instance.Data);
    }
}