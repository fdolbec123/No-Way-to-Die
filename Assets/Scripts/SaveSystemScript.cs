using UnityEngine;
using System.IO;

public class SaveSystemScript
{
    //public DataToSave DataToSaveObject = new DataToSave();
    public static string FileName()

    {
        string saveFile = Application.persistentDataPath + "/progress" + ".nwtd";
        return saveFile;
    }
    public static void Save(object data)
    { 
        File.WriteAllText(FileName(), JsonUtility.ToJson(data));
    }
    public static DataToSave Load()
    {

        if (File.Exists(FileName()))
        {
            string savedContent = File.ReadAllText(FileName());

            DataToSave response = JsonUtility.FromJson<DataToSave>(savedContent);
            return response;
        }
        else
        {
            Debug.Log("There is no save file... Let's create one!");
            DataToSave DataToSaveObject = new DataToSave();

            DataToSaveObject.levelToGo = 0;
            Save(DataToSaveObject);
            return DataToSaveObject;
        }
    }
        
}
[System.Serializable]
public class DataToSave
{
    public int levelToGo;
}