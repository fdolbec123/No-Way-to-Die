using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.Localization.Settings;
using UnityEditor.Localization.Editor;

public class MainMenuScript : MonoBehaviour
{
    //vars:
    public TMP_Dropdown languageMenu;
    //Script for play button:
    public void PlayGame()
    {
        Debug.Log("Button pressed!");
        // Showing this only for Debuging purposes.
    }

    //Script for the options panel:
    public void SaveSettings()
    {
        Debug.Log(languageMenu.value);
        //languageMenu.value is an Int. If the locale table is in the same order as the dropdown menu, the Int value will be matching, so we can use it.
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[languageMenu.value];
        Debug.Log("Saving...");
        PlayerPrefs.Save();
    }


    //Script that close the game:
    public void QuitGame()
    {
        Application.Quit();
    }

}
