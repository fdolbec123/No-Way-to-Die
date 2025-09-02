using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    //Script for play button:
    public void PlayGame()
    {
        Debug.Log("Button pressed!");
        // Showing this only for Debuging purposes.
    }

    //Script for the options panel:


    //Script that close the game:
    public void QuitGame()
    {
        Application.Quit();
    }

}
