using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneScript : MonoBehaviour
{
    public DataToSave DataToSaveObject = new DataToSave();
    private AsyncOperation asyncLoad;
    private bool bLoadDone;
    IEnumerator LoadAsyncScene() // Method that is loading the next level in the background. 
    {
        asyncLoad = SceneManager.LoadSceneAsync(DataToSaveObject.levelToGo + 2, LoadSceneMode.Single); // the "+2" is there to cover the fact that Intro scene and loading level scene are numbered 0 and 1. It means that level 1 has id 3 and so on...
        asyncLoad.allowSceneActivation = false; // We do not activate the scene yet.
        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= 0.9f) // if the scene is mostly loaded (90% of it or more)
            {
                asyncLoad.allowSceneActivation = true; // We let the seen be shown to the player.
            }
            yield return null;
        }
        bLoadDone = asyncLoad.isDone;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bLoadDone = false;
        StartCoroutine(LoadAsyncScene()); // calling the loading method
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
