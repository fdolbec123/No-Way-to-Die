using UnityEngine;
using System.IO;

public class SaveSystemScript
{
    //public DataToSave DataToSaveObject = new DataToSave();


    public static string FileName() // retriving the full path and name of the save file

    {
        string saveFile = Application.persistentDataPath + "/progress" + ".nwtd";
        return saveFile;
    }


    public static void Save(object data) //Writing data to the save file
    {
        File.WriteAllText(FileName(), JsonUtility.ToJson(data));
    }


    public static DataToSave Load() // Loading the data
    {

        if (File.Exists(FileName()))
        {
            string savedContent = File.ReadAllText(FileName());

            DataToSave response = JsonUtility.FromJson<DataToSave>(savedContent);
            return response;
        }
        else
        {
            Debug.Log("There is no save file... Let's create one!"); // We create a new save file here before going further. The save will be directing the player to the intro level.
            DataToSave DataToSaveObject = new DataToSave();

            DataToSaveObject.levelToGo = 0;
            Save(DataToSaveObject);
            return DataToSaveObject;
        }
    }

}



// Here are the vars that can be save in the save file
[System.Serializable]
public class DataToSave
{
    public int levelToGo;
}