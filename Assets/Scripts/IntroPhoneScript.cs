using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroPhoneScript : MonoBehaviour
{
    public bool status;
    public DataToSave DataToSaveObject = new DataToSave();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        status = false;
        //DataToSaveObject.reachEndOfIntro = false;
        DataToSaveObject.levelToGo = 0;
        SaveSystemScript.Save(DataToSaveObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void Answer()
    {
        status = true;
        Debug.Log(status);
        //DataToSaveObject.reachEndOfIntro = true;
        DataToSaveObject.levelToGo = 1;
        SaveSystemScript.Save(DataToSaveObject);
    }
    void OnMouseDown()
    {
        Debug.Log("Here");
        Answer();
    }

}