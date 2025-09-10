using UnityEngine;
using System.IO;

public class SaveSystemScript
{
    public static string FileName()
    {
        string saveFile = Application.persistentDataPath + "/progress" + ".nwtd";
        return saveFile;
    }
    public static void Save(object data)
    { 
        File.WriteAllText(FileName(), JsonUtility.ToJson(data));
    }
    public static void Load()
    {
        string saveContent = File.ReadAllText(FileName());
        //_SaveData = JsonUtility.FromJson<SaveData>(saveContent);
    }
}
[System.Serializable]
public class DataToSave
{
    public bool reachEndOfIntro;
}