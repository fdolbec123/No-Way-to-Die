using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneScript : MonoBehaviour
{
    public DataToSave DataToSaveObject = new DataToSave();
    private AsyncOperation asyncLoad;
    private bool bLoadDone;
    IEnumerator LoadAsyncScene()
    {
        asyncLoad = SceneManager.LoadSceneAsync(DataToSaveObject.levelToGo + 2, LoadSceneMode.Single);
        asyncLoad.allowSceneActivation = false;
        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= 0.9f)
            {
                asyncLoad.allowSceneActivation = true;
            }
            yield return null;
        }
        bLoadDone = asyncLoad.isDone;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bLoadDone = false;
        StartCoroutine(LoadAsyncScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
